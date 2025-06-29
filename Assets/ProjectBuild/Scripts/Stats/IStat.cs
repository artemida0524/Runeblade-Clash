using System;

public interface IStat
{
    string Name { get; }
    int Amount { get; }
    
    event EventHandler OnValueChange;
}
