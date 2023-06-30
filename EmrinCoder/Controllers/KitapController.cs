using EmrinCoder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmrinCoder.Utility;

namespace EmrinCoder.Controllers
{
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
        }
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();

            return View(objKitapList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.Id.ToString()


                });

            ViewBag.KitapTuruList = KitapTuruList;

            if (id == null || id == 0)
            {//ekle
                return View();
            }
            else
            {//Guncelle
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
                if (id == null || id == 0)
                {
                    return NotFound();
                }
                return View(kitapVt);
            }

        }

        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Ekle(kitap);
                _kitapRepository.Kaydet();
                TempData["success"] = "Yeni Kitap Başarıyla Eklenmiştir.";
                return RedirectToAction("Index");
            }
            return View();
        }

        /*public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);

            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }
        */
        /*
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            _kitapRepository.Guncelle(kitap);
            _kitapRepository.Kaydet();
            TempData["success"] = "Kitap Başarıyla Güncellenmiştir.";
            return RedirectToAction("Index");
        }
        */
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);

            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);

            if (kitap == null)
            {
                return NotFound();
            }

            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();
            TempData["success"] = "Kitap Başarıyla Silinmiştir.";
            return RedirectToAction("Index");
        }

    }
}
