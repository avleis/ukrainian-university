# Ukrainian University

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![License: GPL v3](https://img.shields.io/badge/license-GPLv3-blue.svg)](LICENSE)

Навчальні роботи з дисциплін університету: лабораторні, практичні та домашні завдання.

## Зміст

- [Структура репозиторію](#структура-репозиторію)
- [Алгоритми та програмування](#алгоритми-та-програмування)
- [Вимоги](#вимоги)
- [Запуск](#запуск)
- [Ліцензія](#ліцензія)

## Структура репозиторію

```text
ukrainian-university/
├── FirstCourse/                       # 1 курс
│   └── AlgorithmsAndProgramming/      # Алгоритми та програмування
│       ├── AssignmentsForLaboratoryWorks01To09.docx
│       ├── AssignmentsForLaboratoryWorks10To15.docx
│       ├── LaboratoryWork02/
│       │   ├── LaboratoryWork02.sln
│       │   └── LaboratoryWork02/
│       │       ├── LaboratoryWork02.csproj
│       │       └── Program.cs
│       └── ...
├── LICENSE
└── README.md
```

Кожна лабораторна робота є окремим консольним проєктом .NET з власним файлом рішення (`.sln`).

## Алгоритми та програмування

Мова: C#. Платформа: .NET 10.

| №  | Тема                          | Що робить програма                                                                                       |
|----|-------------------------------|----------------------------------------------------------------------------------------------------------|
| [02](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork02) | Лінійні алгоритми | Обчислює кут між двома прямими за їхніми кутовими коефіцієнтами `k1`, `k2` (у радіанах і градусах). |
| [03](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork03) | Розгалуження | Обчислює кусково задану функцію `v(x, y)` залежно від області, в яку потрапляє точка. |
| [04](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork04) | Цикли | Табулює функцію `f(x) = arctg(x) + 1` на відрізку `[10; 20]` з кроком `h = (b − a) / m`. |
| [05](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork05) | Одновимірні масиви | За температурами 12 місяців знаходить найвищу від'ємну та найнижчу додатну температуру. |
| [06](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork06) | Рядки | Об'єднує 10 введених рядків в один і виводить його довжину. |
| [07](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork07) | Двовимірні масиви та методи | Для матриць `A(3×3)`, `Y(5×5)`, `C(4×4)` знаходить максимум і мінімум головної діагоналі. |
| [08](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork08) | Текстові файли | Читає сторони прямокутників з `input.txt` і записує таблицю периметрів і площ у `output.txt`. |
| [09](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork09) | Класи та колекції | Облік результатів регати: введення яхт з клавіатури або файла, виведення за класами, відсортованими за місцем. |
| [10](FirstCourse/AlgorithmsAndProgramming/LaboratoryWork10) | Методи, введення та словники | Консольне меню з п'яти прикладів: перевірка введення, табуляція, дата й час, умови, телефонна книга (`Dictionary`). |

Умови лабораторних робіт:

- 01–09: [`AssignmentsForLaboratoryWorks01To09.docx`](FirstCourse/AlgorithmsAndProgramming/AssignmentsForLaboratoryWorks01To09.docx)
- 10–15: [`AssignmentsForLaboratoryWorks10To15.docx`](FirstCourse/AlgorithmsAndProgramming/AssignmentsForLaboratoryWorks10To15.docx)

### Формат вхідних файлів

**Лабораторна 08.** `input.txt`: у кожному рядку дві сторони прямокутника через пробіл, дробова частина відділяється крапкою.

```text
3 4
2.5 6
10 1.2
```

**Лабораторна 09.** `input.txt`: одна яхта в рядку, поля через `;` у порядку `назва;клас;екіпаж;порт;місце`. Допустимі класи: `Фін`, `Зоряний`, `Торнадо`, `Солинг`. Некоректні рядки пропускаються з повідомленням.

```text
Чайка;Фін;1;Одеса;2
Буревісник;Торнадо;2;Миколаїв;1
Мрія;Фін;1;Херсон;1
```

## Вимоги

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) або новіший
- Будь-яка IDE з підтримкою C#: JetBrains Rider, Visual Studio або VS Code з розширенням C# Dev Kit (необов'язково)

Перевірити встановлену версію:

```bash
dotnet --version
```

## Запуск

Клонувати репозиторій:

```bash
git clone https://github.com/avleis/ukrainian-university.git
cd ukrainian-university
```

Запустити потрібну лабораторну з папки її проєкту:

```bash
cd FirstCourse/AlgorithmsAndProgramming/LaboratoryWork05/LaboratoryWork05
dotnet run
```

Лабораторні 08 і 09 шукають `input.txt` і створюють `output.txt` у поточній робочій папці, тому запускайте їх саме з папки проєкту і покладіть туди `input.txt`.

Також можна відкрити файл `.sln` потрібної роботи в IDE і запустити його звідти.

> **Примітка.** У лабораторній 10 приклад 3 показує дату й час через `MessageBox` (Windows Forms) лише на Windows. На macOS і Linux результат виводиться в консоль.

## Ліцензія

Проєкт поширюється за ліцензією [GNU General Public License v3.0](LICENSE).
