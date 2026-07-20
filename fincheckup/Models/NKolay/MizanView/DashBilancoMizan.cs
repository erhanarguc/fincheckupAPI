
using fincheckup.Models.Beyanname;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fincheckup.Models.NKolay.MizanView
{
    public class DashBilancoMizanDefter
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID,int typeID)
        {
            DashBilancoViewMizanCheck nCheckdefter = new DashBilancoViewMizanCheck();
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_Stok(_year, _compID), "A4-Stoklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2221, 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
            // -
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);
            //nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_OKynkOdSermayeTenzil(_year, _compID), "E1-ÖZKAYNAKLAR Tenzil Hesabı", 1);
            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
            nCheckdefter.SetBilanco(DashBilancoSetMizan.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

            ///

            nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMOzKaynakUTV3(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);

            //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);

            //nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasifBynNw(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);
            if (typeID > 0)
            {
                nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasifByn(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);
            }
            else
            {
                nCheckdefter.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasifBynNzm(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);

            }


            return nCheckdefter.mrequestEntry;
        }
    }
    public class DashBilancoBeyan
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashBilancoViewMizanCheck nCheck = new DashBilancoViewMizanCheck();
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_Stok(_year, _compID), "A4-Stoklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2221, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
            // -
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
            nCheck.SetBilanco(DashBilancoSetBeyan.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

            ///

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMOzKaynakUT(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetBeyan.Get_TOPLAMPasifByn(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);

            //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





            return nCheck.mrequestEntry;
        }
    }
    public class DashBilancoMizan
    {
        public static List<DashBilancoViewMizan> getList(int _year, long _compID)
        {
            DashBilancoViewMizanCheck nCheck = new DashBilancoViewMizanCheck();
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Stok(_year, _compID), "A4-Stoklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2221, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
            // -
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

            ///

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMOzKaynakUT(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasif(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);

            //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





            return nCheck.mrequestEntry;
        }
 
        public static List<DashBilancoViewMizan> getListbynmizan(int _year, long _compID, int typeID = 0)
        {
            DashBilancoViewMizanCheck nCheck = new DashBilancoViewMizanCheck();
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_HazirDegerT(_year, _compID), "A-Hazır Değerler", 10, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_HazirDeger(_year, _compID), "A-Hazır Değerler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MenkulKiymetT(_year, _compID), "A1-Menkul Kıymetler", 11, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MenkulKiymet(_year, _compID), "A1-Menkul Kıymetler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicariAlacakT(_year, _compID), "A2-Ticari Alacaklar", 12, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicariAlacak(_year, _compID), "A2-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacakT(_year, _compID), "A3-Diğer Alacaklar", 13, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak(_year, _compID), "A3-Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_StokT(_year, _compID), "A4-Stoklar", 15, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Stok(_year, _compID), "A4-Stoklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatT(_year, _compID), "A4_- İnşaat ve Onarım", 17, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Insaat(_year, _compID), "A4_- İnşaat ve Onarım", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukT(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 18, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk(_year, _compID), "A5- Gelecek Aylara Ait Giderler ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDonenT(_year, _compID), "A6-Diğer Dönen Varlıklar", 19, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerDonen(_year, _compID), "A6-Diğer Dönen Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTUMT(_year, _compID), "AT-TOPLAM DÖNEN VARLIKLAR", 111, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicAlacakT(_year, _compID), "B1-Ticari Alacaklar", 22, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicAlacak(_year, _compID), "B1-Ticari Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerAlacak1T(_year, _compID), "B2- Diğer Alacaklar", 23, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerAlacak1(_year, _compID), "B2- Diğer Alacaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliDuranT(_year, _compID), "B3-Mali Duran Varlıklar", 24, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliDuran(_year, _compID), "B3-Mali Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiDuranT(_year, _compID), "B4-Maddi Duran Varlıklar", 25, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaddiDuran(_year, _compID), "B4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaddiOlmayanDuranT(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 26, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaddiOlmayanDuran(_year, _compID), "B5-Maddi Olmayan Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TabiT(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 27, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tabi(_year, _compID), "B6-Özel Tükenmeye Tabii Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_Tahakkuk1T(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 28, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_Tahakkuk1(_year, _compID), "B7-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerDuranT(_year, _compID), "B8-Diğer Duran Varlıklar", 29, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerDuran(_year, _compID), "B8-Diğer Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAM1T(_year, _compID), "BT- TOPLAM DURAN VARLIKLAR", 222, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMAktif(_year, _compID), "BTT- TOPLAM AKTİFLER", 2221, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcT(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 30, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliBorc(_year, _compID), "C-Kısa Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcT(_year, _compID), "C1-Ticari Borçlar", 32, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicBorc(_year, _compID), "C1-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcT(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 33, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerBorc(_year, _compID), "C2-Diğer Çeşitli  Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansT(_year, _compID), "C3-Alınan Avanslar", 34, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_AlinanAvans(_year, _compID), "C3-Alınan Avanslar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_InsaatOnarimHakedisT(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 35, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_InsaatOnarimHakedis(_year, _compID), "C3_-Yıllara Yaygın İnşaat ve Onarım Hakedişleri", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_VergiYukT(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 36, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_VergiYuk(_year, _compID), "C4-Ödenencek Vergi ve Diğer Yükümlülükler", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkT(_year, _compID), "C5- Borç ve Gider Karşılıkları", 37, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_BorcKarslk(_year, _compID), "C5- Borç ve Gider Karşılıkları", 0);
            // -
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_KTahakkukT(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 38, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_KTahakkuk(_year, _compID), "C6-Gelecek Aylara Ait Gelirler ve Gider Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakT(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 39, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_YabKaynak(_year, _compID), "C7-Diğer Kısa Vadeli Yabancı Kaynaklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMT(_year, _compID), "CT- Kısa Vadeli Yabancı Kaynaklar Toplamı", 333, 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_MaliBorcUT(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 40, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_MaliBorcU(_year, _compID), "D1- Uzun Vadeli Yükümlülükler Mali Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TicBorcUT(_year, _compID), "D2-Ticari Borçlar", 42, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TicBorcU(_year, _compID), "D2-Ticari Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_DigerBorcUT(_year, _compID), "D3-Diğer Borçlar", 43, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_DigerBorcU(_year, _compID), "D3-Diğer Borçlar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_AlinanAvansUT(_year, _compID), "D4-Alınan Avanslar", 44, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_AlinanAvansU(_year, _compID), "D4-Maddi Duran Varlıklar", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_BorcKarslkUT(_year, _compID), "D5-Borç ve Gider Karşılıkları", 47, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_BorcKarslkU(_year, _compID), "D5-Borç ve Gider Karşılıkları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TahakkukUT(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 48, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_TahakkukU(_year, _compID), "D6-Gelecek Yıllara Ait Gider ve Gelir Tahakkukları", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_YabKaynakUT(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 49, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_YabKaynakU(_year, _compID), "D7-Diğer Uzun Vadeli Yabancı Kaynaklar", 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMTU(_year, _compID), "DT- Uzun Vadeli Yabancı Kaynaklar Toplamı", 444, 0);
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkOdSermayeT(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 50, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkOdSermaye(_year, _compID), "E1-ÖZKAYNAKLAR Ödenmiş Sermaye", 0);
            //nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkOdSermayeTenzil(_year, _compID), "E1-ÖZKAYNAKLAR Tenzil Hesabı", 0);
            
            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkSermayeYedekT(_year, _compID), "E2-Sermaye Yedekleri", 51, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkSermayeYedek(_year, _compID), "E2-Sermaye Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkKarYedekT(_year, _compID), "E3-Kar Yedekleri", 54, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_OKynkKarYedek(_year, _compID), "E3-Kar Yedekleri", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_PrOKynkGcmsKZT(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar", 57, 1);
            nCheck.SetBilanco(DashBilancoSetMizan.Get_PrOKynkGcmsKZ(_year, _compID), "E4-Geçmiş Yıl Kar/Zarar ", 0);

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_OKynkDonemKZT(_year, _compID), "E5-Dönem Kar/Zarar", 59, 0);

            ///

            nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMOzKaynakUT(_year, _compID), "ET-TOPLAM ÖZKAYNAKLAR", 3333, 0);
            if (typeID == 0)
            {
                nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasifByn(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);
            }
            else
            {
                nCheck.SetBilancoHeaderT(DashBilancoSetMizan.Get_TOPLAMPasifBynNzm(_year, _compID), "ETT- TOPLAM PASİFLER", 2223, 0);

            }


            //  nCheck.SetBilancoHeaderT(DashGelirTablosu.Get_TOPLAMKaynakUT(_year, _compID), "F-TOPLAM KAYNAKLAR", 2222, 0);





            return nCheck.mrequestEntry;
        }
    }
    public class DashBilancoViewMizanCheck
    {
        public DashBilancoViewMizanCheck()
        {
            mrequestEntry = new List<DashBilancoViewMizan>();
            countet = 0;
        }
        public List<DashBilancoViewMizan> mrequestEntry { get; set; }
        public int countet { get; set; }
        public void SetBilanco(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int hidden_)
        {
            var mrequest = mrequestEntryCount.OrderBy(x => x.AccountMainID).ToList();
            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequest.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewMizan();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = mrequest[i].AccountMainDescription;
                nDash.AccountMainID = mrequest[i].AccountMainID;
                nDash.Amount = mrequest[i].Amount;

                nDash.CompanyID = mrequest[i].CompanyID;
                nDash.DebitCreditCode = mrequest[i].DebitCreditCode;

                nDash.Year = mrequest[i].Year;
                nDash.IsHidden = hidden_;
                if (nDash.getStatue())
                {
                    mrequestEntry.Add(nDash);
                }

            }

        }

        public void SetBilancoHeaderT(List<DashBilancoViewMizan> mrequestEntryCount, string tname, int typeid_, int hidden_)
        {

            DashBilancoViewMizan nDash = new DashBilancoViewMizan();
            for (int i = 0; i < mrequestEntryCount.Count(); i++)
            {
                countet++;
                nDash = new DashBilancoViewMizan();
                nDash.CounterZone = countet;
                nDash.GroupName = tname;
                nDash.AccountMainDescription = tname;
                nDash.AccountMainID = mrequestEntryCount[i].AccountMainDescription;
                nDash.Amount = mrequestEntryCount[i].Amount;

                nDash.CompanyID = mrequestEntryCount[i].CompanyID;
                nDash.DebitCreditCode = mrequestEntryCount[i].DebitCreditCode;

                nDash.Year = mrequestEntryCount[i].Year;
                nDash.TypeID = typeid_;
                nDash.IsHidden = hidden_;
                if (nDash.getStatue())
                {
                    mrequestEntry.Add(nDash);
                }
            }

        }

    }

    public class DashBilancoViewMizan
    {
        public string AccountMainID { get; set; }
        public string AccountMainDescription { get; set; }
        public string DebitCreditCode { get; set; }
        public double Amount { get; set; }
        public long CompanyID { get; set; }
        public int IsHidden { get; set; }
        public int Year { get; set; }
        public string GroupName { get; set; }
        public int CounterZone { get; set; }
        public int TypeID { get; set; }




        public bool getStatue()
        {
            int ncoun = 0;
            Boolean chk = true;
            if (Amount != 0) { ncoun++; }

            if (ncoun == 0)
            {
                chk = false;
            }

            return chk;
        }


    }

}
