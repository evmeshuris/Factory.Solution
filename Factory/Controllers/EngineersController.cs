using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      //TODO: show machines licensed for engineer
      // var licensed_engineers = _db.Engineers
      //   .Join(_db.MachineEngineer, e => e.EngineerId, me => me.EngineerId, (e, me)
      //     => new {
      //       e.EngineerId, 
      //       me.MachineId,
      //       e.Name,
      //     })
      //   .Join(_db.Machines, e_me => e_me.MachineId, m => m.MachineId, (e_me, m)
      //     => new {
      //       e_me.EngineerId,
      //       e_me.MachineId,
      //       EngineerName = e_me.Name,
      //       MachineName = m.Name,
      //       m.Description
      //     })
      //     .ToList();

      // var all_eng = 
      //   from eng in _db.Engineers
      //   join l_eng in licensed_engineers on eng.EngineerId equals l_eng.EngineerId into gj
      //   from s_eng in gj.DefaultIfEmpty()
      //   select new {
      //     eng.EngineerId,
      //     s_eng.MachineId,
      //     EngineerName = eng.Name,
      //     s_eng.MachineName,
      //     s_eng.Description
      //   };

      // return View(all_eng.ToList());
      return View(_db.Engineers.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      {
        _db.MachineEngineer.Add( new MachineEngineer(){MachineId = MachineId ,EngineerId = engineer.EngineerId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.JoinEntities)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Description");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
        _db.MachineEngineer.Add(new MachineEngineer() { MachineId = MachineId, EngineerId = engineer.EngineerId });
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    
  }
}