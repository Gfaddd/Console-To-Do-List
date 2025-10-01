using Console_To_Do_List;
using System.Text.Json;

bool stay = true;
int menu;

TaskHandler taskHandler = new();
taskHandler.LoadInfo();
do
{
	try
	{
		do
		{
			PrintMenu();
			Console.Write("Введите значение: ");
			if (int.TryParse(Console.ReadLine(), out menu))
				break;
			else
				Console.Clear();
		} while (true);

		switch (menu)
		{
			case 1:
				{
					string taskName;
					do
					{
						Console.Write("Введите название задачи: ");
						taskName = Console.ReadLine();
					} while (string.IsNullOrEmpty(taskName.Trim()));
					Console.WriteLine($"Для задачи установленно новое имя: {taskName}");
					taskHandler.AddTask(new(taskName));
					break;
				}
			case 2:
				{
					PrintTasks();
					break;
				}
			case 3:
				{
					string userInput;
					int index = -1,
						subMenu;
					bool stayInChoosenTaskMenu = true,
						 stayInTaskMenu = true;

					do
					{
						try
						{
							stayInChoosenTaskMenu = true;

							do
							{
								Console.WriteLine("\n\nВыберите задачу:");
								PrintTasks();
								Console.Write("Введите номер задачи (quit - чтобы выйти): ");
								userInput = Console.ReadLine();
								if (userInput.Trim().ToLower().Equals("quit"))
								{
									stayInTaskMenu = false;
									break;
								}
							} while (!int.TryParse(userInput, out index));

							if (!taskHandler.CheckIndex(index))
							{
								Console.WriteLine("Такого индекса нет");
								continue;
							}



							while (stayInChoosenTaskMenu && stayInTaskMenu)
							{

								do
								{
									PrintTaskMenu();
									Console.Write("Введите пункт меню: ");
								} while (!int.TryParse(Console.ReadLine(), out subMenu));

								switch (subMenu)
								{
									case 1:
										{
											taskHandler.CompleteTask(index);
											Console.WriteLine("Выбранная задача была выполнена");
											break;
										}
									case 2:
										{
											string newName;
											do
											{
												Console.Write("Введите новое название задачи: ");
												newName = Console.ReadLine();
											} while (string.IsNullOrEmpty(newName.Trim()));
											taskHandler.EditTask(index, newName);
											Console.WriteLine($"Для задачи установленно новое имя: {newName}");





											break;
										}
									case 3:
										{
											taskHandler.RemoveTask(index);
											Console.WriteLine("Выбранная задача была удалена");
											break;
										}
									case 4:
										{
											stayInChoosenTaskMenu = false;
											break;
										}
									default:
										{
											Console.WriteLine($"Вы ввели несуществующий номер: {subMenu}");
											break;
										}
								}

							}
						}
						catch(ArgumentOutOfRangeException e)
						{
							Console.WriteLine("Вы ввели несуществующий индекс");
						}
					} while (stayInTaskMenu);


					break;
				}
			case 4:
				{
					stay = false;
					taskHandler.SaveInfo();
					break;
				}
			default:
				{
					Console.Clear();
					Console.WriteLine($"Вы ввели несуществующий номер: {menu}");
					break;
				}
		}
		Console.WriteLine("\n\n");
	}
	catch(Exception e)
	{
		Console.WriteLine($"Возникла ошибка: {e.Message}");
	}
} while (stay);

void PrintMenu()
{
	Console.WriteLine("\t\tМеню");
	Console.WriteLine("=====================================");
	Console.WriteLine("\t1.Добавить задачу");
	Console.WriteLine("\t2.Просмотреть задачи");
	Console.WriteLine("\t3.Выбрать задачу");
	Console.WriteLine("\t4.Выйти");
	Console.WriteLine("=====================================\n\n");
}

void PrintTaskMenu()
{
	Console.WriteLine("\n\tМеню выбора задачи");
	Console.WriteLine("-------------------------------------");
	Console.WriteLine("\t1.Выполнить задачу");
	Console.WriteLine("\t2.Редактировать задачи");
	Console.WriteLine("\t3.Удалить задачу");
	Console.WriteLine("\t4.Назад");
	Console.WriteLine("-------------------------------------\n\n");
}

void PrintTasks() => Console.WriteLine($"Список задач:\n{taskHandler.GetInfo()}");

//FileNotFoundException
