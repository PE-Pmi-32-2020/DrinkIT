select * from users;
create function UserAdd(_username varchar,_password varchar)
returns int as
$$
begin
    insert into users(username,password )
    values (_username,_password);
    if FOUND then
    return 1;
    else return 0;
    end if;
end
$$
language plpgsql;

CREATE OR REPLACE FUNCTION insert_something( _val varchar,_val2 varchar)
    RETURNS int as $$
DECLARE count int;
BEGIN
    INSERT INTO users (id, username,password) VALUES( _val,_val2);
    GET DIAGNOSTICS count = ROW_COUNT;
    RETURN count;
END;
$$ language plpgsql;
drop function  UserAdd(_username varchar,_password varchar);