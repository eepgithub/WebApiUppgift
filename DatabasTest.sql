CREATE TABLE Users (
    Id bigint not null identity (1,1) primary key,
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    Email nvarchar(50) not null,
    Password nvarchar(50) not null
)

CREATE TABLE Issues (
    Id bigint not null identity(1,1) primary key,
    UserId bigint not null references Users(id),
    Created datetime not null,
    Updated datetime,
    status nvarchar(50) not null
)