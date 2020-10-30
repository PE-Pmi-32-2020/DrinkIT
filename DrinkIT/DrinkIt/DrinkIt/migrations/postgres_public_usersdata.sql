create table usersdata
(
    id                     serial  not null
        constraint usersdata_pkey
            primary key,
    water_norm             integer not null,
    wake_up_time           time,
    sleep_time             time,
    period_of_notification time    not null,
    user_id                integer
        constraint usersdata_user_id_fkey
            references users
);

