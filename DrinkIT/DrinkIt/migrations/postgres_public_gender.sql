create table gender
(
    id   serial       not null
        constraint gender_pkey
            primary key,
    name varchar(255) not null
        constraint gender_sex_key
            unique
);

alter table gender
    owner to postgres;

INSERT INTO public.gender (id, name) VALUES (1, 'MALE');
INSERT INTO public.gender (id, name) VALUES (2, 'FEMALE');
INSERT INTO public.gender (id, name) VALUES (3, 'MIXED');