# Lab 1
### Програму цієї лабораторної роботи було створено з дотриманням принципів програмування :

**<ins>Принцип DRY (Don't Repeat Yourself)</ins>\
Суть: Не дублюйте одну й ту ж логіку в коді.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L19-L25)\
У класі Money перевірка правильності значень units і cents реалізована в одному місці — у конструкторі.
Інші частини коду, які працюють з грошима (наприклад, Product.Price, DecreasePrice), не повторюють цю перевірку, а покладаються на те, що об’єкт Money вже створений з правильними значеннями.
Таким чином, дотримано принципу DRY — уникнення дублювання логіки перевірки значень грошей.\
<ins>Принцип KISS (Keep It Simple, Stupid)</ins>\
Суть: Легкість у розумінні й мінімальна складність.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L84-L89)\
Простий, зрозумілий метод без зайвої логіки — чітко дотримується KISS.\
<ins>Принцип YAGNI (You Ain’t Gonna Need It)</ins>\
Суть: Не реалізовувати того, чого ще не потребуємо.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L134-L144)\
<ins>Принцип Composition Over Inheritance</ins>\
Суть: Краще включення об'єктів, ніж спадкування.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L148)\
Product має Money, а не є підкласом Money.\
<ins>Принцип Program to Interfaces, not Implementations</ins>\
Суть: Працювати через інтерфейси, а не конкретні класи.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L8-L12)\
<ins>Принцип Fail Fast</ins>\
Суть: Помилки мають з'являтися якомога раніше.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L22)\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L86)\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L94)\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L115)\
<ins>Принцип SOLID</ins>\
<ins>Single Responsibility Principle (Принцип єдиної відповідальності)</ins>\
Суть:Кожен клас повинен мати одну відповідальність.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L14)\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L43)\
Клас Product відповідає тільки за опис товару.\
Клас Money відповідає лише за зберігання та валідацію грошових значень.\
<ins>Open/Closed Principle (Принцип відкритості/закритості)</ins>\
Суть: Клас повинен бути відкритий для розширення, але закритий для змін.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L8-L12)\
Можна створювати нові типи, які реалізують IPrice, не змінюючи існуючий код.\
<ins>Interface Segregation Principle (Принцип розділення інтерфейсів)</ins>\
Суть:Інтерфейси повинні бути простими та конкретними.\
[Приклад в коді](./Lab1/Product%20storage/Program.cs#L8-L12)\..**
