using EmrinCoder.Utility;
using EmrinCoder.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmrinCoder.Controllers
{
    public class KitapTuruController : Controller
    {
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapTuruController(IKitapTuruRepository context)//Constructor Class 

        {

            _kitapTuruRepository = context;
        }
        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {

                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.Kaydet();       //SaveChanges yapmazsak Bilgiler veritabanına kaydedilmez.
                TempData["success"] = "Yeni Kitap Türü Başarıyla Eklenmiştir.";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);

            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
        }
        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {

            _kitapTuruRepository.Guncelle(kitapTuru);
            _kitapTuruRepository.Kaydet();       //SaveChanges yapmazsak Bilgiler veritabanına kaydedilmez.
            TempData["success"] = "Kitap Türü Başarıyla Güncellenmiştir.";
            return RedirectToAction("Index");
        }


        public IActionResult Sil(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);

            if (kitapTuruVt == null)
            {
                return NotFound();
            }

            return View(kitapTuruVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru = _kitapTuruRepository.Get(u => u.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["success"] = "Kitap Türü Başarıyla Silinmiştir.";
            return RedirectToAction("Index");

        }

    }
}
