using BO.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMobile.Modeles
{
    class ReservationModel : ModeleBase
    {
        private static ReservationModel _instance;
        private static object verrou = new object();


        public static ReservationModel Instance {
            get
            {
                if(_instance == null)
                {
                    lock(verrou)
                    {
                        if(_instance == null)
                        {
                            _instance = new ReservationModel();
                        }
                    }
                }
                return _instance;
            }
        }

        private Menu _menu;
        public Menu Menu
        {
            get
            {
                return _menu;
            }
            set
            {
                Set(ref _menu, value);

                //toutes les 3sec je vais chercher les infos sur l'api
            }
        }


    }
}
