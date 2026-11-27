# Ukrainian University

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![License: GPL v3](https://img.shields.io/badge/license-GPLv3-blue.svg)](LICENSE)

Навчальні роботи з дисциплін університету: лабораторні, практичні та домашні завдання.

## Зміст

- [Дисципліни](#дисципліни)
- [Структура репозиторію](#структура-репозиторію)
- [Вимоги](#вимоги)
- [Запуск](#запуск)
- [Ліцензія](#ліцензія)

## Дисципліни

| Курс | Дисципліна                      | Мова | Папка                                                                       |
|------|---------------------------------|------|-----------------------------------------------------------------------------|
| 1    | Алгоритмізація та програмування | C#   | [`AlgorithmsAndProgramming`](FirstCourse/AlgorithmsAndProgramming)          |

## Структура репозиторію

```text
ukrainian-university/
├── <Курс>/                            # FirstCourse, SecondCourse, ...
│   └── <Дисципліна>/                  # наприклад, AlgorithmsAndProgramming
│       ├── Documentation/
│       │   ├── Assignments/           # умови робіт
│       │   └── Reports/               # звіти до робіт
│       └── LaboratoryWorkNN/          # одна робота
│           ├── LaboratoryWorkNN.sln
│           └── LaboratoryWorkNN/
│               ├── LaboratoryWorkNN.csproj
│               └── Program.cs
├── LICENSE
└── README.md
```

- Кожна робота є окремим консольним проєктом .NET з власним файлом рішення (`.sln`).
- Номер роботи завжди двозначний: `LaboratoryWork02`, `LaboratoryWork10`.
- Умову роботи можна знайти в `Documentation/Assignments`, а опис рішення, приклади введення й результати роботи програми — у звіті `Documentation/Reports/LaboratoryWorkNN.docx`.

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

Запустити потрібну роботу з папки її проєкту:

```bash
cd <Курс>/<Дисципліна>/LaboratoryWorkNN/LaboratoryWorkNN
dotnet run
```

Наприклад:

```bash
cd FirstCourse/AlgorithmsAndProgramming/LaboratoryWork05/LaboratoryWork05
dotnet run
```

Також можна відкрити файл `.sln` потрібної роботи в IDE і запустити його звідти.

> **Примітка.** Роботи, які читають або записують файли (`input.txt`, `output.txt`), шукають їх у поточній робочій папці, тому запускайте їх саме з папки проєкту. Роботи, що використовують Windows Forms (наприклад, `MessageBox`), показують вікна лише на Windows, а на macOS і Linux виводять результат у консоль.

## Ліцензія

Проєкт поширюється за ліцензією [GNU General Public License v3.0](LICENSE).
