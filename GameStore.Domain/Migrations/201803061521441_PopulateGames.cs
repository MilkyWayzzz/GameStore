namespace GameStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Games(Name, Description, Category, Price) 
VALUES 
	('SimCity', '����������������� ��������� ����� � ����! �������� ����� ����� �����', '���������', 1499.00),
	('TITANFALL', '��� ���� ��������� ��� �� ���������, ��� ����� ������������������� ��������, ������� � ���������, � ������� � ������', '�����', 2299.00),
	('Battlefield 4', 'Battlefield 4 � ��� ������������ ��� �����, ������ ������ ������, ��������� ����� ��������������, ������ ������� ���', '�����', 899.40),
	('The Sims 4', '� ���������� ������� �������� ���� ������� ���� ���� �����. �� � ������� The Sims 4 ��� ����������� ����� �����! 
		��� ������ � ���, ��� � � ��� ����, ��� ����������, ��� �������� � ������������ ���� ���', '���������', 15.00),
	('Dark Souls 2', '����������� ����������� �������� ������ ����� �������� ������� ������ ����� ���������� ���������. Dark Souls II ��������� 
		������ �����, ����� ������� � ����� ���. ���� ���� ��������� � ������ � ������� ��������� Dark Souls ����� ��������.', 'RPG', 949.00),
	('The Elder Scrolls V: Skyrim', '����� �������� ������ �������� ������� ��������� �� ����� ����������. ������ ������������ �� ������� ���������� ����� �����, 
		� ���������� ��������. � ���� ��, ��� ������������� ������� ������, � ��� ��������� �������� � ����������� �������. ������ ������� �������� � ���� 
		������� ������� �� ����������������� � ��������, � ����� �������� ����� ����� ����������� �������.', 'RPG', 1399.00),
	('FIFA 14', '�����������, ��������, ������������� ������! ����������� �������� �������� FIFA ���� ��� ����� ��������� ����������, ���������� ���������� ���� �
		 ������ ���� � ����������� �������� � ����.', '���������', 699.00),
	('Need for Speed Rivals', '�������� ��� ����������� ������ ����. ������� ����� ����� ��������� � ��������������������� ������� � ���������� ������������� 
		����� ��������� � ��������. �������� ������� � ���, � ������� ���� ������ ��� ��������� � ������ � �������. ', '���������', 15.00),
	('Crysis 3', '�������� ���� ��������������� � 2047 ����, � ��� ��������� ��������� � ���� �������.', '�����', 1299.00),
	('Dead Space 3', '� Dead Space 3 ����� ����� � ������� ������ ���� ������ ������������ � ����������� �����������, ����� ������ � ������������� �����������.', '�����', 499.00);");
        }
        
        public override void Down()
        {
        }
    }
}
