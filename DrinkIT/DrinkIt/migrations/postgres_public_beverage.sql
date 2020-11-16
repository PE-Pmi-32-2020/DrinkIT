create table beverage
(
    id   serial       not null
        constraint baverage_pkey
            primary key,
    name varchar(255) not null
        constraint baverage_drink_key
            unique
);

INSERT INTO public.beverage (id, name) VALUES (6, 'Tea');
INSERT INTO public.beverage (id, name) VALUES (1, 'Juice');
INSERT INTO public.beverage (id, name) VALUES (4, 'Cola');
INSERT INTO public.beverage (id, name) VALUES (3, 'Water');
INSERT INTO public.beverage (id, name) VALUES (2, 'Milk');
INSERT INTO public.beverage (id, name) VALUES (5, 'Cofee');