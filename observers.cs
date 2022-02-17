using System;
using System.Collections.Generic;

namespace Observer
{
  class observers
  {
    static void Main(string[] args)
    {
      Detector detector = new Detector();
      Detectores detectores = new Detectores("Jose");
      detector.Attach(detectores);

      Detectores detectores1 = new Detectores("Gilberto");
      detector.Attach(detectores1);

      detector.cambios = 5;
      detector.cambios = 7;
      detector.cambios = 45;
    }
  }

  //Cambios en proyecto
  //Detector

  interface ITema
  {
    void Attach(IObservador observador);
    void Notificacion();
  }

  interface IObservador
  {
    void Actualizar(ITema tema);
  }

  //ITEMA
  class Detector : ITema
  {
    private List<IObservador> _observador;

    public float cambios { get { return _cambios; } set { _cambios = value; Notificacion();}}
    private float _cambios;
    public Detector()
    {
      _observador = new List<IObservador>();
    }

    public void Attach(IObservador observador)
    {
      _observador.Add(observador);
    }

    public void Notificacion()
    {
      _observador.ForEach(o => { o.Actualizar(this);});
    }
  }

  //IOBSERVADOR
  class Detectores : IObservador
  {
    public string NombreAdmin { get; set; }
    public Detectores(String nombre)
    {
      NombreAdmin = nombre;
    }
    
    public void Actualizar(ITema tema)
    {
      if (tema is Detector detector)
      {
        Console.WriteLine(String.Format("{0} hizo {1} cambios en el proyecto", NombreAdmin, detector.cambios));
      }
    }
  }
}
