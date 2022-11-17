using System;

Set empty1 = new EmptySet();
Set empty2 = new EmptySet();
Set empty3 = new EmptySet();
Set empty4 = new EmptySet();


PairSet pair1 = new PairSet(empty1, empty2);

PairSet pair2 = new PairSet(empty3, empty4);

Set union = pair1.Union(pair2);

Console.WriteLine(union.IsIn(empty1));