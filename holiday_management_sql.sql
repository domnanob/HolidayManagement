-- you should use this code seperately if the db already created!
use master

go

alter database holiday_management set single_user with rollback immediate

drop database if exists holiday_management
-- 
create database holiday_management
-- end
begin TRY
	begin TRANSACTION

	use holiday_management

	create table centers (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		center_name varchar(50)
	)
	PRINT 'centers created successfully!'

	create table institutions (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		institution_name varchar(50),
		center_id uniqueidentifier,
		constraint fk_institutions_centers foreign key (center_id) references centers(id) on delete cascade
	)
	PRINT 'institutions created successfully!'

	create table role_groups (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		permission_level int,
		group_name varchar(20)
	)
	PRINT 'role_groups created successfully!'

	create table roles (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		role_name varchar(20),
		role_group_id uniqueidentifier
		constraint fk_roles_role_group foreign key (role_group_id) references role_groups(id) on delete cascade
	)
	PRINT 'roles created successfully!'

	create table user_data (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		email varchar(50),
		birth date,
		phone varchar(20),
		children int,
		fullname varchar(50)
	)
	PRINT 'user_data created successfully!'

	create table users (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		user_data_id uniqueidentifier unique,
		username varchar(20),
		password text,
		constraint fk_user_userdata foreign key (user_data_id) references user_data(id) on delete cascade
	)
	PRINT 'users created successfully!'
	
	create table user_institutions (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		user_id uniqueidentifier,
		institution_id uniqueidentifier,
		role_id uniqueidentifier,
		created_at date,
		active tinyint,
		constraint fk_user_institutions_users foreign key (user_id) references users(id) on delete cascade,
		constraint fk_user_institutions_institutions foreign key (institution_id) references institutions(id) on delete cascade,
		constraint fk_user_institutions_roles foreign key (role_id) references roles(id) on delete cascade
	)
	PRINT 'user_institutions created successfully!'

	create table holiday_requests (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		user_institution_id uniqueidentifier,
		requested_day date,
		created_at date,
		allowed_at date,
		declined_at date,
		message text,
		constraint fk_holiday_requests_user_institutions foreign key (user_institution_id) references user_institutions(id) on delete cascade,
	)

	create table login_logs (
		id int IDENTITY(1,1) Primary Key,
		user_id uniqueidentifier,
		login_date datetime,
		constraint fk_login_logs_users foreign key (user_id) references users(id) on delete cascade
	)
	PRINT 'login_logs created successfully!'

	insert into role_groups(permission_level,group_name) values(0, 'admin')
	insert into role_groups(permission_level,group_name) values(1, 'user')

	insert into roles(role_name, role_group_id) values('admin', (Select Id From role_groups where group_name = 'admin'))
	insert into roles(role_name, role_group_id) values('teacher', (Select Id From role_groups where group_name = 'user'))
	insert into roles(role_name, role_group_id) values('principal', (Select Id From role_groups where group_name = 'user'))

	insert into centers(id, center_name) values('1D0DCC87-0A7E-4F5B-A9EA-B280C8F5F955', 'Vasvármegyei Szakképzési Centrum') 
	insert into institutions (id, institution_name, center_id) values('5B1CD299-12D7-475F-80EF-E47E8C7F3019', 'Nádasdy Tamás Technikum és Kollégium', '1D0DCC87-0A7E-4F5B-A9EA-B280C8F5F955')

	insert into user_data(id, fullname, birth, email, children, phone) values ('77E5B60C-CBEA-4DFD-BB98-68904CDEE801', 'dr. Admin Admin', '2002-11-28', 'admin@vvszc.hu', 0, '+36303627517')
	insert into users(user_data_id, username, password) values ('77E5B60C-CBEA-4DFD-BB98-68904CDEE801', 'admin', 'A82D01D3B9C7315E991589E029C5A77CA1EBD01F51A22D10CBB3780B4D4C24F1-Alice-5DDE095006706E27C3F8BA020C4CB60A')
	insert into user_institutions(institution_id, user_id, role_id, created_at, active) values ('5B1CD299-12D7-475F-80EF-E47E8C7F3019', (Select id from users where username = 'admin'), (Select id from roles where roles.role_name = 'teacher'), CURRENT_DATE, 1)
	
	commit TRANSACTION
	PRINT 'Database created successfully!'

end TRY

begin CATCH

	IF @@ERROR <> 0
		ROLLBACK TRANSACTION
		 PRINT 'Error: ' + CONVERT(VARCHAR(255), ERROR_NUMBER()) + ' - ' + ERROR_MESSAGE()
end CATCH