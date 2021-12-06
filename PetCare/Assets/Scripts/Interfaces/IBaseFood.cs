using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseFood
{  
   public int FilledAmount { get; }

   public void instantiateFood();
}
