using Users.Data.Entities;

namespace Users.Data.Common;

public static class DatabaseSeeds
{
    internal static IEnumerable<Role> Roles => new[]
    {
        new Role
        {
            Name = "user",
            Weight = 7,
            Description = "Роль - пользователь. Вручается каждому зарегистрированному человеку в системе."
        },
        new Role
        {
            Name = "vip_user",
            Weight = 6,
            Description = "Роль - пользователь с платной подпиской. Оформил подписку на ПС или платно поддержал автора."
        },
        new Role
        {
            Name = "author",
            Weight = 5,
            Description = "Роль - автор/писатель. Количество пользователей с ролью не должно превышать 300 человек."
        },
        new Role
        {
            Name = "critic",
            Weight = 4,
            Description = "Роль - критик. Количество пользователей с ролью не должно превышать 10 человек."
        },
        new Role
        {
            Name = "moderator",
            Weight = 3,
            Description = "Роль - модератор. Количество пользователей с ролью не должно превышать 20 человек."
        },
        new Role
        {
            Name = "admin",
            Weight = 2,
            Description = "Роль - администратор. Количество пользователей с ролью не должно превышать 5 человек."
        },
        new Role
        {
            Name = "owner",
            Weight = 1,
            Description = "Роль - владелец. В ПС только один пользователь с данной ролью."
        },
    };

    internal static IEnumerable<User> Users => new[]
    {
        new User
        {
            LastName = "Цыпин",
            FirstName = "Илья",
            Email = "tsypin.i.p@mail.ru",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Tsypin1"),
            RoleName = "owner"
        },
        new User
        {
            LastName = "Садоводов",
            FirstName = "Василий",
            Email = "sad_vas@gmail.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("String1"),
            RoleName = "critic"
        },
        new User
        {
            LastName = "Леванов",
            FirstName = "Андрей",
            Email = "leva_writer@mail.ru",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("String1"),
            RoleName = "author"
        }
    };
}