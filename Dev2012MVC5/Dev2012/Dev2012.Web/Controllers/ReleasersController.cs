using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dev2012.Web.Models;
using Dev2012.Web.ViewModel;

namespace Dev2012.Web.Controllers
{
    public class ReleasersController : BaseController
    {
        private QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        /// <summary>
        /// GET: Releasers
        /// </summary>
        /// <param name="pageCount">Số trang muốn lấy dữ liệu</param>
        /// <param name="pageSize">Số lượng bản ghi tối đa trên 1 trang</param>
        /// <returns></returns>
        public ActionResult Index(int pageCount = 1, int pageSize = 10)
        {
            int skipRecord = pageSize * (pageCount - 1);

            BasePaging<Releaser> res = new BasePaging<Releaser>();
            res.PageCount = pageCount;
            res.PageSize = pageSize;
            res.Data = db.Releaser.OrderBy(x => x.Id).Skip(skipRecord).Take(pageSize).ToList();
            res.TotalRecord = db.Releaser.Count();

            return View(res);
        }

        // GET: Releasers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Releaser releaser = db.Releaser.Find(id);
            if (releaser == null)
            {
                return HttpNotFound();
            }
            return View(releaser);
        }

        // GET: Releasers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Releasers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Notes,Status,IsDelete")] Releaser releaser)
        {
            if (ModelState.IsValid)
            {
                db.Releaser.Add(releaser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(releaser);
        }

        // GET: Releasers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Releaser releaser = db.Releaser.Find(id);
            if (releaser == null)
            {
                return HttpNotFound();
            }
            return View(releaser);
        }

        // POST: Releasers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Notes,Status,IsDelete")] Releaser releaser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(releaser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(releaser);
        }

        // GET: Releasers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Releaser releaser = db.Releaser.Find(id);
            if (releaser == null)
            {
                return HttpNotFound();
            }
            return View(releaser);
        }

        // POST: Releasers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Releaser releaser = db.Releaser.Find(id);
            db.Releaser.Remove(releaser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
