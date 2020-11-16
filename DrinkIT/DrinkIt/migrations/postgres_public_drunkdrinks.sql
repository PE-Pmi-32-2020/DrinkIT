create table drunkdrinks
(
    id          serial not null
        constraint drunkdrinks_pkey
            primary key,
    volume      integer
        constraint drunkdrinks_volume_check
            check (volume > 0),
    time        timestamp,
    beverage_id integer
        constraint drunkdrinks_beverage_id_fkey
            references beverage,
    user_id     integer
        constraint drunkdrinks_user_id_fkey
            references users
);
