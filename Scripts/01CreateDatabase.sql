CREATE TABLE tenants (
    tenantid serial primary key not null,
    name varchar(100) not null,
    email varchar(320) not null,
    datecreated timestamp with time zone not null,
    isactive boolean not null
    )