using CRUDApi.Models;
using CRUDApi.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRUDApi.Requests
{
    public static class Requests
    {
        public static WebApplication RegisterEndpoins(this WebApplication app)
        {
            app.MapPost("/register", (BooksDbContext context, UserReqBody user) => Register(context, user))
                .WithValidator<UserReqBody>();

            app.MapPost("/create",
               [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
            (BooksDbContext context, BookReqBody newBook, IBookService service, IValidator<BookReqBody> validator) => Create(context, newBook, service, validator))
            .WithValidator<BookReqBody>();

            app.MapGet("/get",
                [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, standard")]
            (BooksDbContext context, Guid id, IBookService service) => Get(context, id, service));

            app.MapGet("/list", (BooksDbContext context) => List(context));

            app.MapPut("/update",
                [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
            (BooksDbContext context, BookReqBody newBook, Guid id, IBookService service) => Update(context, newBook, id, service))
                .WithValidator<BookReqBody>();

            app.MapDelete("/delete",
                [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
            (BooksDbContext context, Guid id, IBookService service) => Delete(context, id, service));

            return app;

            static IResult Register(BooksDbContext context, UserReqBody user)
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.Username,
                    Surname = user.Surname,
                    Password = user.Password,
                    Role = "standard",
                    Id = new Guid(),
                };
                context.Add(newUser);
                context.SaveChanges();
                return Results.Ok(user);
            }

            static IResult Create(BooksDbContext context, BookReqBody newBook, IBookService service, IValidator<BookReqBody> validator)
            {
                var book = service.Create(newBook);
                context.Books.Add(book);
                context.SaveChanges();
                return Results.Ok(book);
            }

            static IResult Get(BooksDbContext context, Guid id, IBookService service)
            {
                var result = service.Get(context, id);
                if (result is null)
                {
                    return Results.NotFound("Book not found");
                }
                return Results.Ok(result);
            }

            static IResult List(BooksDbContext context)
            {
                var result = context.Books.ToList();
                return Results.Ok(result);
            }


            static IResult Update(BooksDbContext context, BookReqBody newBook, Guid id, IBookService service)
            {
                var result = service.Update(context, newBook, id);
                if (result is null) return Results.NotFound("Book not found");

                context.SaveChanges();

                return Results.Ok(result);
            }

            static IResult Delete(BooksDbContext context, Guid id, IBookService service)
            {
                var book = service.Get(context, id);

                if (book is null) return Results.NotFound("Book not found");

                context.Books.Remove(book);
                context.SaveChanges();

                return Results.Ok();
            }
        }
    }
}
