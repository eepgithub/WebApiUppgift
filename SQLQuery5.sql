CREATE TABLE Issues (
    Id bigint not null identity(1,1) primary key,
    Customer nvarchar(50) not null,
    Created datetime not null,
    Updated datetime,
    status nvarchar(50) not null
)