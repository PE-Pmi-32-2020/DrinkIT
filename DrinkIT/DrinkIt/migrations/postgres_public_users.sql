create table users
(
    id       serial       not null
        constraint users_pkey
            primary key,
    username varchar(255) not null
        constraint users_username_key
            unique,
    password varchar(255) not null
);
