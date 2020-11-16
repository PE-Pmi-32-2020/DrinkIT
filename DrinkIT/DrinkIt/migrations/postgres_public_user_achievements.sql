create table user_achievements
(
    id             serial not null
        constraint userachievements_pk
            primary key,
    user_id        integer
        constraint "UserAchievements_user_id_fkey"
            references users,
    achievement_id integer
        constraint "UserAchievements_achievement_id_fkey"
            references achievements
);
