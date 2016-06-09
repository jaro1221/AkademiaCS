using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreatorPostaci
{
    public class Settings : INotifyPropertyChanged
    {
       
          private int weight = 60;
          public int Weight
          {
              get { return this.weight; }
              set
              {
                  if (this.weight != value)
                  {
                      this.weight = value;
                      this.NotifyPropertyChanged("Weight");
                  }
              }
          }

          public event PropertyChangedEventHandler PropertyChanged;

          public void NotifyPropertyChanged(string propName)
          {
              if(this.PropertyChanged != null)
              {
                  this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
              }
          }
      } 
   }
