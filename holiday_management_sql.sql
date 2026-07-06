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
		center_name varchar
	)
	PRINT 'centers created successfully!'

	create table institutions (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		institution_name varchar,
		center_id uniqueidentifier,
		constraint fk_institutions_centers foreign key (center_id) references centers(id) on delete cascade
	)
	PRINT 'institutions created successfully!'

	create table role_groups (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		permission_level int,
		group_name varchar
	)
	PRINT 'role_groups created successfully!'

	create table roles (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		role_name varchar,
		role_group_id uniqueidentifier
		constraint fk_roles_role_group foreign key (role_group_id) references role_groups(id) on delete cascade
	)
	PRINT 'roles created successfully!'

	create table user_data (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		email varchar unique,
		birth date,
		phone varchar(20),
		children int
	)
	PRINT 'user_data created successfully!'

	create table users (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		user_data_id uniqueidentifier unique,
		username varchar,
		password text,
		role_id varchar(20),
		constraint fk_user_userdata foreign key (user_data_id) references user_data(id) on delete cascade
	)
	PRINT 'users created successfully!'
	
	create table user_institutions (
		id uniqueidentifier Primary Key DEFAULT newsequentialid(),
		user_id uniqueidentifier,
		institution_id uniqueidentifier,
		role_id uniqueidentifier,
		constraint fk_user_institutions_users foreign key (user_id) references users(id) on delete cascade,
		constraint fk_user_institutions_institutions foreign key (institution_id) references institutions(id) on delete cascade,
		constraint fk_user_institutions_roles foreign key (role_id) references roles(id) on delete cascade
	)
	PRINT 'user_institutions created successfully!'

	create table login_logs (
		id int IDENTITY(1,1) Primary Key,
		user_id uniqueidentifier,
		login_date datetime,
		constraint fk_login_logs_users foreign key (user_id) references users(id) on delete cascade
	)
	PRINT 'login_logs created successfully!'
	
	commit TRANSACTION
	PRINT 'Database created successfully!'
end TRY

begin CATCH

	IF @@ERROR <> 0
		ROLLBACK TRANSACTION
		 PRINT 'Error: ' + CONVERT(VARCHAR(255), ERROR_NUMBER()) + ' - ' + ERROR_MESSAGE()
end CATCH