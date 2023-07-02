using EmrinCoder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmrinCoder.Utility;
using Microsoft.AspNetCore.Authorization;

namespace EmrinCoder.Controllers
{   //authorize attribute ile sadece admin rolüne sahip kullanıcılar bu controller a erişebilir.
    public class KitapController : Controller
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository, IWebHostEnvironment webHostEnvironment)
        {
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize(Roles = "Admin,Ogrenci")]
        public IActionResult Index()
        {
            List<Kitap> objKitapList = _kitapRepository.GetAll(includeProps:"KitapTuru").ToList();

            return View(objKitapList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
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
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult EkleGuncelle(Kitap kitap, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string kitapPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
                    {

                        file.CopyTo(fileStream);
                    }

                    kitap.ResimUrl = @"\img\" + file.FileName;

                }


                if (kitap.Id == 0)
                {
                    _kitapRepository.Ekle(kitap);
                    TempData["success"] = "Yeni Kitap Başarıyla Eklenmiştir.";
                }
                else
                {
                    _kitapRepository.Guncelle(kitap);
                    TempData["success"] = "Kitap Başarıyla Güncellenmiştir.";
                }

                _kitapRepository.Kaydet();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = UserRoles.Role_Admin)]
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
        [Authorize(Roles = UserRoles.Role_Admin)]
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
