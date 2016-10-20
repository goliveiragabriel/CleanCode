using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class Boundaries
    {
        /// <summary>
        /// Don't use this. It is an older .NET Framework type. It is slower than the generic Dictionary type. But if an old program uses Hashtable, it is helpful to know how to use this type.
        /// <seealso cref="https://www.dotnetperls.com/hashtable"/>
        /// </summary>
        Hashtable sensors = new Hashtable();
        Hashtable<Sensor> sensors2 = new Hashtable<Sensor>();

        public Boundaries()
        {
        }

        /// <summary>
        /// Exemplo para mostrar que algumas vezes as implementações System.Collections e outras bibliotecas de 3 podem ser aquém do que necessitamos
        /// Ex.: Metodo Remove() de Hashtable
        /// </summary>
        public void Example1()
        {
            sensors.Add(1, new Sensor());
            int sensorId = 0;
            // Não é CleanCode
            Sensor sensor = sensors[sensorId] as Sensor;
            // Solução : entretanto isto não resolve o problema de que outras bibliotecas podem ter métodos aquem do que precisamos
            Sensor sensor2 = sensors2[sensorId];
            // No entanto passar instancias de Hashtable<T> podem ser critico caso a interface sofra alteração 
            // Exemplo: remover o método RemoveAt da interface
        }

    }

    class Sensor
    {

    }

    internal class Hashtable<T> : Hashtable where T : Sensor
    {
        public override T this[object key]
        {
            get
            {
                return base[key] as T;
            }
            set
            {
                base[key] = value;
            }
        }

        internal bool RemoveAt(int id)
        {
            return true;
        }
    }

    class Sensors
    {
        private Hashtable<Sensor> sensors = new Hashtable<Sensor>();

        public Sensor GetById(int sensorId)
        {
            return sensors[sensorId];
        }
    }

}
