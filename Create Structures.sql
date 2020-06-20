drop schema grades;

create schema grades;

use grades;

create table student(
	id int primary key auto_increment,
    `name` varchar(100) not null
);

create table `subject`(
	id int primary key auto_increment,
    `name` varchar(100) not null
);

create table student_grade(
	id int primary key auto_increment,
	student_id int not null,
    subject_id int not null,
    grade decimal(3,2) not null,
    foreign key (student_id) references student(id),
    foreign key (subject_id) references `subject`(id)
);