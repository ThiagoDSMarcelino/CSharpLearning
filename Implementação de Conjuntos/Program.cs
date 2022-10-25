using System;

Set empty1 = new EmptySet();
Set empty2 = new EmptySet();
Set empty3 = new EmptySet();
Set empty4 = new EmptySet();


PairSet pair1 = new PairSet();
pair1.A = empty1;
pair1.B = empty2;

PairSet pair2 = new PairSet();
pair2.A = empty3;
pair2.B = empty4;


Set union = pair1.Union(pair2);

Console.WriteLine(union.IsIn(empty1));