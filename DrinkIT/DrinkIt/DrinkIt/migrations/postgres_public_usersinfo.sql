create table usersinfo
(
    id            serial       not null
        constraint usersinfo_pkey
            primary key,
    name          varchar(255) not null,
    age           integer
        constraint usersinfo_age_check
            check (age > 3),
    weight        double precision
        constraint usersinfo_weight_check
            check (weight > (0)::double precision),
    date_of_birth date         not null,
    gender_id     integer
        constraint usersinfo_gender_id_fkey
            references gender,
    user_id       integer
        constraint usersinfo_user_id_fkey
            references users
);
