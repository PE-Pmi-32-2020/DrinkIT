create table achievements
(
    id   serial       not null
        constraint achievements_pkey
            primary key,
    name varchar(255) not null
        constraint achievements_name_of_achievement_key
            unique
);

INSERT INTO public.achievements (id, name) VALUES (3, '1 day');
INSERT INTO public.achievements (id, name) VALUES (4, '2 day');
INSERT INTO public.achievements (id, name) VALUES (5, '3 days');
INSERT INTO public.achievements (id, name) VALUES (10, 'gold cup');
INSERT INTO public.achievements (id, name) VALUES (6, '10 days');
INSERT INTO public.achievements (id, name) VALUES (7, '1 week');
INSERT INTO public.achievements (id, name) VALUES (9, '3l in day');
INSERT INTO public.achievements (id, name) VALUES (1, 'wake up');
INSERT INTO public.achievements (id, name) VALUES (2, 'drink more');
INSERT INTO public.achievements (id, name) VALUES (8, '5l in day');