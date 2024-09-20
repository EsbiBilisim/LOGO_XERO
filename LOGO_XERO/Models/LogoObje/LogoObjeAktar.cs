using DevExpress.XtraDiagram.Base;
using DevExpress.XtraMap.Drawing.DirectD3D9;
using LOGO_XERO.Models.LOGO_XERO_M;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityObjects;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace LOGO_XERO.Models.LogoObje
{
    public class LogoObjeAktar
    {

        LOGO_XERO_PARAMETRELER parametre = new LOGO_XERO_PARAMETRELER();

        public LogoObjeAktar(LOGO_XERO_PARAMETRELER _parametre)
        {
            parametre = _parametre;
        }
        static UnityObjects.UnityApplication UnityApp;
        public bool Baglan()
        {
            try
            {
                if (UnityApp == null)
                    UnityApp = new UnityApplication();
                if (UnityApp.LoggedIn)
                { return true; }
                else
                {
                    //if (parametre.LOGOPAKETSECIMI == 1)
                    //{
                    return UnityApp.LoginEx(parametre.OBJEKULLANICIADI, parametre.OBJEKULLANICISIFRE, Convert.ToInt32(parametre.FIRMANO), "MARE.DLL;L10005;FSLDKFMLSEEEKMFVCMCK");
                    //}
                    //else
                    //{
                    //    bool sn= UnityApp.Login(logoKullaniciAdi, logoKullaniciSifre, Convert.ToInt32(firmaNumarasi),0);
                    //    return sn;
                    //}

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string SatisSiparisiIptal(int RefNo)
        {
            if (Baglan())
            {
                try
                {
                    UnityObjects.Data siparis = UnityApp.NewDataObject(DataObjectType.doSalesOrderSlip);
                    string geriDonecekDeger;
                    if (siparis.Delete(RefNo))
                    {
                        geriDonecekDeger = "true";
                        return geriDonecekDeger;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < siparis.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(siparis.ValidateErrors[i].Error);
                        }

                        if (siparis.ErrorCode != 0)
                        {
                            sb.AppendLine(siparis.ErrorDesc);
                            sb.AppendLine(siparis.DBErrorDesc);

                        }
                        geriDonecekDeger = sb.ToString();
                        return geriDonecekDeger;
                    }
                }
                catch (Exception ex)
                {
                    return "Hata : " + ex.ToString();
                }

            }

            else
            {
                return "Obje Login Hatası!";
            }

        }
        public string AlisSiparisiIptal(int RefNo)
        {
            if (Baglan())
            {
                try
                {
                    UnityObjects.Data siparis = UnityApp.NewDataObject(DataObjectType.doPurchOrderSlip);
                    string geriDonecekDeger;
                    if (siparis.Delete(RefNo))
                    {
                        geriDonecekDeger = "true";
                        return geriDonecekDeger;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < siparis.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(siparis.ValidateErrors[i].Error);
                        }

                        if (siparis.ErrorCode != 0)
                        {
                            sb.AppendLine(siparis.ErrorDesc);
                            sb.AppendLine(siparis.DBErrorDesc);

                        }
                        geriDonecekDeger = sb.ToString();
                        return geriDonecekDeger;
                    }
                }
                catch (Exception ex)
                {
                    return "Hata : " + ex.ToString();
                }

            }

            else
            {
                return "Obje Login Hatası!";
            }

        }
        public string[] SatisSiparisiEkle(OBJE_SIPARIS_M gelensiparis)
        {
            if (Baglan())
            {
                try
                {
                    UnityObjects.Data siparis = UnityApp.NewDataObject(UnityObjects.DataObjectType.doSalesOrderSlip);
                    siparis.New();
                    siparis.DataFields.FieldByName("NUMBER").Value = "~";
                    siparis.DataFields.FieldByName("DATE").Value = gelensiparis.TARIH;
                    siparis.DataFields.FieldByName("ARP_CODE").Value = gelensiparis.CARIKODU;
                    siparis.DataFields.FieldByName("GL_CODE").Value = gelensiparis.MUHASEBEKODU;
                    siparis.DataFields.FieldByName("AUXIL_CODE").Value = gelensiparis.OZELKOD;
                    siparis.DataFields.FieldByName("AUTH_CODE").Value = gelensiparis.YETKIKODU;
                    siparis.DataFields.FieldByName("TRADING_GRP").Value = gelensiparis.TICARIISLEMGRUBU;
                    siparis.DataFields.FieldByName("DOC_NUMBER").Value = gelensiparis.BELGENO;
                    siparis.DataFields.FieldByName("SHIPPING_AGENT").Value = gelensiparis.TASIYICIKODU;
                    DateTime saat = Convert.ToDateTime(gelensiparis.SAAT);
                    Object tm = 0;
                    UnityApp.PackTime(saat.Hour, saat.Minute, saat.Second, ref tm);
                    siparis.DataFields.FieldByName("TIME").Value = tm;
                    siparis.DataFields.FieldByName("ORDER_STATUS").Value = gelensiparis.SIPARISSTATU;
                    siparis.DataFields.FieldByName("DATE_CREATED").Value = gelensiparis.TARIH;
                    siparis.DataFields.FieldByName("AFFECT_RISK").Value = 1;
                    siparis.DataFields.FieldByName("NOTES1").Value = gelensiparis.ACIKLAMA1;
                    siparis.DataFields.FieldByName("NOTES2").Value = gelensiparis.ACIKLAMA2;
                    siparis.DataFields.FieldByName("NOTES3").Value = gelensiparis.ACIKLAMA3;
                    siparis.DataFields.FieldByName("NOTES4").Value = gelensiparis.ACIKLAMA4;
                    siparis.DataFields.FieldByName("NOTES5").Value = gelensiparis.ACIKLAMA5;
                    siparis.DataFields.FieldByName("NOTES6").Value = gelensiparis.ACIKLAMA6;
                    siparis.DataFields.FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                    siparis.DataFields.FieldByName("SOURCE_WH").Value = gelensiparis.AMBAR;
                    siparis.DataFields.FieldByName("SOURCE_COST_GRP").Value = gelensiparis.MALIYETAMBAR;
                    siparis.DataFields.FieldByName("DIVISION").Value = gelensiparis.ISYERI;
                    siparis.DataFields.FieldByName("DEPARTMENT").Value = gelensiparis.BOLUM;
                    siparis.DataFields.FieldByName("FACTORY").Value = gelensiparis.FABRIKA;
                    siparis.DataFields.FieldByName("PAYMENT_CODE").Value = gelensiparis.CARIODEMEKODU;
                    siparis.DataFields.FieldByName("PROJECT_CODE").Value = gelensiparis.PROJEKODU;
                    siparis.DataFields.FieldByName("SHIPMENT_TYPE").Value = gelensiparis.TESLIMSEKLIKODU;
                    siparis.DataFields.FieldByName("ARP_CODE_SHPM").Value = gelensiparis.SEVKIYATHESABIKODU;
                    siparis.DataFields.FieldByName("EINVOICE").Value = gelensiparis.EFATURA;
                    siparis.DataFields.FieldByName("EINVOICE_TYPE ").Value = gelensiparis.EINVOICE_TYPE;
                    siparis.DataFields.FieldByName("WITH_PAYMENT").Value = gelensiparis.ODEMELIMI;
                    siparis.DataFields.FieldByName("CURRSEL_TOTAL").Value = gelensiparis.CURRSELTOTAL;
                    siparis.DataFields.FieldByName("RC_RATE").Value = gelensiparis.FIRMARAPORLAMAKURU;
                    siparis.DataFields.FieldByName("SHIPLOC_CODE").Value = gelensiparis.SEVKADRESIKODU;
                    siparis.DataFields.FieldByName("UPD_TRCURR").Value = gelensiparis.AKTARILDIGINDAISLEMDOVIZIDEGISSIN;
                    siparis.DataFields.FieldByName("UPD_CURR").Value = gelensiparis.AKTARILDIGINDAFIYALANDIRMADOVIZIDEGISSIN;


                    if (gelensiparis.CURRSELDETAILS == 4)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                    }

                    if (gelensiparis.CURRSELDETAILS == 2)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_TOTAL").Value = 2;
                        siparis.DataFields.FieldByName("TC_RATE").Value = Convert.ToDouble(gelensiparis.ISLEMDOVIZKURU);
                        siparis.DataFields.FieldByName("CURR_TRANSACTIN").Value = Convert.ToDouble(gelensiparis.ISLEMDOVIZIKODU);
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                    }
                    if (gelensiparis.CURRSELDETAILS == 0 || gelensiparis.CURRSELDETAILS == 1)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                        siparis.DataFields.FieldByName("CURR_TRANSACTIN").Value = 0;
                    }


                    Lines detay = siparis.DataFields.FieldByName("TRANSACTIONS").Lines;
                    for (int i = 0; i < Convert.ToInt16(gelensiparis.SATIRLAR.Count); i++)
                    {
                        if (detay.AppendLine())
                        {
                            detay[detay.Count - 1].FieldByName("TYPE").Value = gelensiparis.SATIRLAR[i].SATIRTIPI;
                            detay[detay.Count - 1].FieldByName("MASTER_CODE").Value = gelensiparis.SATIRLAR[i].STOKKODU;
                            detay[detay.Count - 1].FieldByName("UNIT_CODE").Value = gelensiparis.SATIRLAR[i].BIRIM;
                            detay[detay.Count - 1].FieldByName("TRANS_DESCRIPTION").Value = gelensiparis.SATIRLAR[i].SATIRACIKLAMA;
                            detay[detay.Count - 1].FieldByName("QUANTITY").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].MIKTAR);
                            detay[detay.Count - 1].FieldByName("PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].FIYAT);
                            detay[detay.Count - 1].FieldByName("VAT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].KDV);
                            detay[detay.Count - 1].FieldByName("VAT_INCLUDED").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].KDVDAHIL);
                            detay[detay.Count - 1].FieldByName("DELVRY_CODE").Value = gelensiparis.SATIRLAR[i].TEKLIFSATIRID;
                            detay[detay.Count - 1].FieldByName("AUXIL_CODE2").Value = gelensiparis.SATIRLAR[i].FIYATGURUBU;
                            detay[detay.Count - 1].FieldByName("DUE_DATE").Value = gelensiparis.SATIRLAR[i].TESLIMTARIHI;

                            detay[detay.Count - 1].FieldByName("CANDEDUCT").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATLI);
                            detay[detay.Count - 1].FieldByName("DEDUCT_CODE").Value = gelensiparis.SATIRLAR[i].TEVKIFATKODU;
                            detay[detay.Count - 1].FieldByName("DEDUCTION_PART2").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATBOLEN);
                            detay[detay.Count - 1].FieldByName("DEDUCTION_PART1").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATCARPAN);


                            detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].SATIRAMBARNO);
                            detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR);

                            if (gelensiparis.CURRSELDETAILS == 4)
                            {
                                detay[detay.Count - 1].FieldByName("PC_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZLIFIYAT);
                                detay[detay.Count - 1].FieldByName("PR_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKURU);
                                detay[detay.Count - 1].FieldByName("CURR_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKODU);
                            }
                            if (gelensiparis.CURRSELDETAILS == 2)
                            {
                                detay[detay.Count - 1].FieldByName("EXCLINE_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZLIFIYAT);
                                detay[detay.Count - 1].FieldByName("CURR_TRANSACTIN").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKODU);
                            }
                            if (gelensiparis.CURRSELDETAILS == 0 || gelensiparis.CURRSELDETAILS == 1)
                            {
                                detay[detay.Count - 1].FieldByName("CURR_TRANSACTIN").Value = 0;
                            }


                        }

                        if (gelensiparis.SATIRLAR[i].ISKONTO1 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO1);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }
                        if (gelensiparis.SATIRLAR[i].ISKONTO2 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO2);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }
                        if (gelensiparis.SATIRLAR[i].ISKONTO3 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO3);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }

                    }

                    UnityObjects.Lines defnfldslist_lines = siparis.DataFields.FieldByName("DEFNFLDSLIST").Lines;
                    defnfldslist_lines.AppendLine();
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("MODULENR").Value = 8;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("TEXTFLDS50").Value = gelensiparis.PAZARLAMATIPI;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;

                    defnfldslist_lines.AppendLine();
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("MODULENR").Value = 8;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("NUMFLDS50").Value = gelensiparis.TANIMLIODEMETIPINUMARASI;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;


                    string geriDonecekDeger;
                    if (siparis.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(siparis.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());
                        return new string[] { geriDonecekDeger, siparis.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() , siparis.DataFields.FieldByName("NUMBER").Value.ToString()
                };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < siparis.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(siparis.ValidateErrors[i].Error);//logo hatası
                        }

                        if (siparis.ErrorCode != 0)
                        {
                            sb.AppendLine(siparis.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(siparis.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }
        public string[] SatinAlmaSiparisiEkle(OBJE_SIPARIS_M gelensiparis)
        {
            if (Baglan())
            {
                try
                {
                    UnityObjects.Data siparis = UnityApp.NewDataObject(UnityObjects.DataObjectType.doPurchOrderSlip);
                    siparis.New();
                    siparis.DataFields.FieldByName("NUMBER").Value = "~";
                    siparis.DataFields.FieldByName("DATE").Value = gelensiparis.TARIH;
                    siparis.DataFields.FieldByName("ARP_CODE").Value = gelensiparis.CARIKODU;
                    siparis.DataFields.FieldByName("GL_CODE").Value = gelensiparis.MUHASEBEKODU;
                    siparis.DataFields.FieldByName("AUXIL_CODE").Value = gelensiparis.OZELKOD;
                    siparis.DataFields.FieldByName("AUTH_CODE").Value = gelensiparis.YETKIKODU;
                    siparis.DataFields.FieldByName("TRADING_GRP").Value = gelensiparis.TICARIISLEMGRUBU;
                    siparis.DataFields.FieldByName("DOC_NUMBER").Value = gelensiparis.BELGENO;
                    siparis.DataFields.FieldByName("SHIPPING_AGENT").Value = gelensiparis.TASIYICIKODU;
                    DateTime saat = Convert.ToDateTime(gelensiparis.SAAT);
                    Object tm = 0;
                    UnityApp.PackTime(saat.Hour, saat.Minute, saat.Second, ref tm);
                    siparis.DataFields.FieldByName("TIME").Value = tm;
                    siparis.DataFields.FieldByName("ORDER_STATUS").Value = gelensiparis.SIPARISSTATU;
                    siparis.DataFields.FieldByName("DATE_CREATED").Value = gelensiparis.TARIH;
                    siparis.DataFields.FieldByName("AFFECT_RISK").Value = 1;
                    siparis.DataFields.FieldByName("NOTES1").Value = gelensiparis.ACIKLAMA1;
                    siparis.DataFields.FieldByName("NOTES2").Value = gelensiparis.ACIKLAMA2;
                    siparis.DataFields.FieldByName("NOTES3").Value = gelensiparis.ACIKLAMA3;
                    siparis.DataFields.FieldByName("NOTES4").Value = gelensiparis.ACIKLAMA4;
                    siparis.DataFields.FieldByName("NOTES5").Value = gelensiparis.ACIKLAMA5;
                    siparis.DataFields.FieldByName("NOTES6").Value = gelensiparis.ACIKLAMA6;
                    siparis.DataFields.FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                    siparis.DataFields.FieldByName("SOURCE_WH").Value = gelensiparis.AMBAR;
                    siparis.DataFields.FieldByName("SOURCE_COST_GRP").Value = gelensiparis.MALIYETAMBAR;
                    siparis.DataFields.FieldByName("DIVISION").Value = gelensiparis.ISYERI;
                    siparis.DataFields.FieldByName("DEPARTMENT").Value = gelensiparis.BOLUM;
                    siparis.DataFields.FieldByName("FACTORY").Value = gelensiparis.FABRIKA;
                    siparis.DataFields.FieldByName("PAYMENT_CODE").Value = gelensiparis.CARIODEMEKODU;
                    siparis.DataFields.FieldByName("PROJECT_CODE").Value = gelensiparis.PROJEKODU;
                    siparis.DataFields.FieldByName("SHIPMENT_TYPE").Value = gelensiparis.TESLIMSEKLIKODU;
                    siparis.DataFields.FieldByName("ARP_CODE_SHPM").Value = gelensiparis.SEVKIYATHESABIKODU;
                    siparis.DataFields.FieldByName("EINVOICE").Value = gelensiparis.EFATURA;
                    siparis.DataFields.FieldByName("EINVOICE_TYPE ").Value = gelensiparis.EINVOICE_TYPE;
                    siparis.DataFields.FieldByName("WITH_PAYMENT").Value = gelensiparis.ODEMELIMI;
                    siparis.DataFields.FieldByName("CURRSEL_TOTAL").Value = gelensiparis.CURRSELTOTAL;
                    siparis.DataFields.FieldByName("RC_RATE").Value = gelensiparis.FIRMARAPORLAMAKURU;
                    siparis.DataFields.FieldByName("SHIPLOC_CODE").Value = gelensiparis.SEVKADRESIKODU;
                    siparis.DataFields.FieldByName("UPD_TRCURR").Value = gelensiparis.AKTARILDIGINDAISLEMDOVIZIDEGISSIN;
                    siparis.DataFields.FieldByName("UPD_CURR").Value = gelensiparis.AKTARILDIGINDAFIYALANDIRMADOVIZIDEGISSIN;


                    if (gelensiparis.CURRSELDETAILS == 4)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                    }

                    if (gelensiparis.CURRSELDETAILS == 2)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_TOTAL").Value = 2;
                        siparis.DataFields.FieldByName("TC_RATE").Value = Convert.ToDouble(gelensiparis.ISLEMDOVIZKURU);
                        siparis.DataFields.FieldByName("CURR_TRANSACTIN").Value = Convert.ToDouble(gelensiparis.ISLEMDOVIZIKODU);
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                    }
                    if (gelensiparis.CURRSELDETAILS == 0 || gelensiparis.CURRSELDETAILS == 1)
                    {
                        siparis.DataFields.FieldByName("CURRSEL_DETAILS").Value = gelensiparis.CURRSELDETAILS;
                        siparis.DataFields.FieldByName("CURR_TRANSACTIN").Value = 0;
                    }


                    Lines detay = siparis.DataFields.FieldByName("TRANSACTIONS").Lines;
                    for (int i = 0; i < Convert.ToInt16(gelensiparis.SATIRLAR.Count); i++)
                    {
                        if (detay.AppendLine())
                        {
                            detay[detay.Count - 1].FieldByName("TYPE").Value = gelensiparis.SATIRLAR[i].SATIRTIPI;
                            detay[detay.Count - 1].FieldByName("MASTER_CODE").Value = gelensiparis.SATIRLAR[i].STOKKODU;
                            detay[detay.Count - 1].FieldByName("UNIT_CODE").Value = gelensiparis.SATIRLAR[i].BIRIM;
                            detay[detay.Count - 1].FieldByName("TRANS_DESCRIPTION").Value = gelensiparis.SATIRLAR[i].SATIRACIKLAMA;
                            detay[detay.Count - 1].FieldByName("QUANTITY").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].MIKTAR);
                            detay[detay.Count - 1].FieldByName("PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].FIYAT);
                            detay[detay.Count - 1].FieldByName("VAT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].KDV);
                            detay[detay.Count - 1].FieldByName("VAT_INCLUDED").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].KDVDAHIL);
                            detay[detay.Count - 1].FieldByName("DELVRY_CODE").Value = gelensiparis.SATIRLAR[i].TEKLIFSATIRID;
                            detay[detay.Count - 1].FieldByName("AUXIL_CODE2").Value = gelensiparis.SATIRLAR[i].FIYATGURUBU;
                            detay[detay.Count - 1].FieldByName("DUE_DATE").Value = gelensiparis.SATIRLAR[i].TESLIMTARIHI;

                            detay[detay.Count - 1].FieldByName("CANDEDUCT").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATLI);
                            detay[detay.Count - 1].FieldByName("DEDUCT_CODE").Value = gelensiparis.SATIRLAR[i].TEVKIFATKODU;
                            detay[detay.Count - 1].FieldByName("DEDUCTION_PART2").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATBOLEN);
                            detay[detay.Count - 1].FieldByName("DEDUCTION_PART1").Value = Convert.ToInt32(gelensiparis.SATIRLAR[i].TEVKIFATCARPAN);


                            detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].SATIRAMBARNO);
                            detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR);

                            if (gelensiparis.CURRSELDETAILS == 4)
                            {
                                detay[detay.Count - 1].FieldByName("PC_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZLIFIYAT);
                                detay[detay.Count - 1].FieldByName("PR_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKURU);
                                detay[detay.Count - 1].FieldByName("CURR_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKODU);
                            }
                            if (gelensiparis.CURRSELDETAILS == 2)
                            {
                                detay[detay.Count - 1].FieldByName("EXCLINE_PRICE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZLIFIYAT);
                                detay[detay.Count - 1].FieldByName("CURR_TRANSACTIN").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].DOVIZKODU);
                            }
                            if (gelensiparis.CURRSELDETAILS == 0 || gelensiparis.CURRSELDETAILS == 1)
                            {
                                detay[detay.Count - 1].FieldByName("CURR_TRANSACTIN").Value = 0;
                            }


                        }

                        if (gelensiparis.SATIRLAR[i].ISKONTO1 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO1);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }
                        if (gelensiparis.SATIRLAR[i].ISKONTO2 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO2);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }
                        if (gelensiparis.SATIRLAR[i].ISKONTO3 > 0)
                        {
                            if (detay.AppendLine())
                            {
                                detay[detay.Count - 1].FieldByName("TYPE").Value = "2";
                                detay[detay.Count - 1].FieldByName("QUANTITY").Value = "0";
                                detay[detay.Count - 1].FieldByName("SOURCE_WH").Value = gelensiparis.SATIRLAR[i].SATIRAMBARNO;
                                detay[detay.Count - 1].FieldByName("SALESMAN_CODE").Value = gelensiparis.SATISELEMANIKODU;
                                detay[detay.Count - 1].FieldByName("SOURCE_COST_GRP").Value = gelensiparis.SATIRLAR[i].SATIRMALIYETAMBAR;
                                detay[detay.Count - 1].FieldByName("DISCOUNT_RATE").Value = Convert.ToDouble(gelensiparis.SATIRLAR[i].ISKONTO3);
                                detay[detay.Count - 1].FieldByName("AFFECT_RISK").Value = 1;
                            }
                        }

                    }

                    UnityObjects.Lines defnfldslist_lines = siparis.DataFields.FieldByName("DEFNFLDSLIST").Lines;
                    defnfldslist_lines.AppendLine();
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("MODULENR").Value = 8;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("TEXTFLDS50").Value = gelensiparis.PAZARLAMATIPI;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;

                    defnfldslist_lines.AppendLine();
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("MODULENR").Value = 8;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("NUMFLDS50").Value = gelensiparis.TANIMLIODEMETIPINUMARASI;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                    defnfldslist_lines[defnfldslist_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;


                    string geriDonecekDeger;
                    if (siparis.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(siparis.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());
                        return new string[] { geriDonecekDeger, siparis.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() , siparis.DataFields.FieldByName("NUMBER").Value.ToString()
                };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < siparis.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(siparis.ValidateErrors[i].Error);//logo hatası
                        }

                        if (siparis.ErrorCode != 0)
                        {
                            sb.AppendLine(siparis.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(siparis.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }

        public string[] StokKartiEkle(Logo.STOK.Rootobject stok)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doMaterial);
                    item.New();
                    item.DataFields.FieldByName("CARD_TYPE").Value = 1;
                    item.DataFields.FieldByName("CODE").Value = stok.CODE;
                    item.DataFields.FieldByName("NAME").Value = stok.NAME;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = stok.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = stok.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = stok.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = stok.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = stok.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = stok.AUTH_CODE;
                    item.DataFields.FieldByName("GROUP_CODE").Value = stok.GROUP_CODE;
                    item.DataFields.FieldByName("PRODUCER_CODE").Value = stok.PRODUCER_CODE;
                    item.DataFields.FieldByName("CAN_DEDUCT").Value = stok.CAN_DEDUCT;
                    item.DataFields.FieldByName("KDV_DEPT_NR").Value = stok.KDV_DEPT_NR;
                    item.DataFields.FieldByName("NAME3").Value = stok.NAME3;
                    item.DataFields.FieldByName("NAME4").Value = stok.NAME4;
                    item.DataFields.FieldByName("DEDUCT_CODE").Value = stok.DEDUCT_CODE;
                    item.DataFields.FieldByName("PURCH_DEDUCT_CODE").Value = stok.PURCH_DEDUCT_CODE;
                    item.DataFields.FieldByName("SALE_DEDUCTION_PART1").Value = stok.SALE_DEDUCTION_PART1;
                    item.DataFields.FieldByName("SALE_DEDUCTION_PART2").Value = stok.SALE_DEDUCTION_PART2;
                    item.DataFields.FieldByName("PURCH_DEDUCTION_PART1").Value = stok.PURCH_DEDUCTION_PART1;
                    item.DataFields.FieldByName("PURCH_DEDUCTION_PART2").Value = stok.PURCH_DEDUCTION_PART2;
                    item.DataFields.FieldByName("TRACK_TYPE").Value = stok.TRACK_TYPE;
                    item.DataFields.FieldByName("LOCATION_TRACKING").Value = stok.LOCATION_TRACKING;
                    item.DataFields.FieldByName("VAT").Value = stok.VAT;
                    item.DataFields.FieldByName("SELVAT").Value = stok.SELVAT;
                    item.DataFields.FieldByName("RETURNVAT").Value = stok.RETURNVAT;
                    item.DataFields.FieldByName("SELPRVAT").Value = stok.SELPRVAT;
                    item.DataFields.FieldByName("RETURNPRVAT").Value = stok.RETURNPRVAT;
                    item.DataFields.FieldByName("DIST_LOT_UNITS").Value = stok.DIST_LOT_UNITS;
                    item.DataFields.FieldByName("COMB_LOT_UNITS").Value = stok.COMB_LOT_UNITS;
                    item.DataFields.FieldByName("LOTS_DIVISIBLE").Value = stok.LOTS_DIVISIBLE;
                    item.DataFields.FieldByName("ADDTAXPURCHBRWS").Value = stok.ADDTAXPURCHBRWS;
                    item.DataFields.FieldByName("ADDTAXSALESBRWS").Value = stok.ADDTAXSALESBRWS;
                    item.DataFields.FieldByName("DATE_CREATED").Value = stok.DATE_CREATED;
                    item.DataFields.FieldByName("HOUR_CREATED").Value = stok.HOUR_CREATED;
                    item.DataFields.FieldByName("MIN_CREATED").Value = stok.MIN_CREATED;
                    item.DataFields.FieldByName("SEC_CREATED").Value = stok.SEC_CREATED;
                    item.DataFields.FieldByName("UNITSET_CODE").Value = stok.UNITSET_CODE;
                    item.DataFields.FieldByName("MARKCODE").Value = stok.MARKCODE;



                    UnityObjects.Lines units_lines = item.DataFields.FieldByName("UNITS").Lines;

                    foreach (var birimm in stok.UNITS.items)
                    {
                        units_lines.AppendLine();
                        units_lines[units_lines.Count - 1].FieldByName("UNIT_CODE").Value = birimm.UNIT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("CONV_FACT1").Value = birimm.CONV_FACT1;
                        units_lines[units_lines.Count - 1].FieldByName("CONV_FACT2").Value = birimm.CONV_FACT2;
                        //
                        units_lines[units_lines.Count - 1].FieldByName("WIDTH").Value = birimm.WIDTH;
                        units_lines[units_lines.Count - 1].FieldByName("LENGTH").Value = birimm.LENGTH;
                        units_lines[units_lines.Count - 1].FieldByName("HEIGHT").Value = birimm.HEIGHT;
                        units_lines[units_lines.Count - 1].FieldByName("AREA").Value = birimm.AREA;
                        units_lines[units_lines.Count - 1].FieldByName("VOLUME").Value = birimm.VOLUME;
                        units_lines[units_lines.Count - 1].FieldByName("WEIGHT").Value = birimm.WEIGHT;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_VOLUME").Value = birimm.GROSS_VOLUME;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_WEIGHT").Value = birimm.GROSS_WEIGHT;
                        //
                        units_lines[units_lines.Count - 1].FieldByName("WIDTH_CODE").Value = birimm.WIDTH_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("LENGTH_CODE").Value = birimm.LENGTH_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("HEIGHT_CODE").Value = birimm.HEIGHT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("AREA_CODE").Value = birimm.AREA_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("VOLUME_CODE").Value = birimm.VOLUME_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("WEIGHT_CODE").Value = birimm.WEIGHT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_VOL_CODE").Value = birimm.GROSS_VOL_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_WGHT_CODE").Value = birimm.GROSS_WGHT_CODE;

                        if (birimm.BARCODE_LIST.items.Count() > 0)
                        {
                            UnityObjects.Lines barcode_list0 = units_lines[units_lines.Count - 1].FieldByName("BARCODE_LIST").Lines;
                            foreach (var brkd in birimm.BARCODE_LIST.items)
                            {
                                barcode_list0.AppendLine();
                                barcode_list0[barcode_list0.Count - 1].FieldByName("BARCODE").Value = brkd.BARCODE;
                                barcode_list0[barcode_list0.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                            }
                        }

                    }

                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }
        public string[] StokKartiDuzenle(Logo.STOK.Rootobject stok)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doMaterial);
                    item.Read(stok.INTERNAL_REFERENCE);


                    item.DataFields.FieldByName("CODE").Value = stok.CODE;
                    item.DataFields.FieldByName("NAME").Value = stok.NAME;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = stok.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = stok.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = stok.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = stok.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = stok.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = stok.AUTH_CODE;
                    item.DataFields.FieldByName("GROUP_CODE").Value = stok.GROUP_CODE;
                    item.DataFields.FieldByName("PRODUCER_CODE").Value = stok.PRODUCER_CODE;
                    item.DataFields.FieldByName("CAN_DEDUCT").Value = stok.CAN_DEDUCT;
                    item.DataFields.FieldByName("KDV_DEPT_NR").Value = stok.KDV_DEPT_NR;
                    item.DataFields.FieldByName("NAME3").Value = stok.NAME3;
                    item.DataFields.FieldByName("NAME4").Value = stok.NAME4;
                    item.DataFields.FieldByName("DEDUCT_CODE").Value = stok.DEDUCT_CODE;
                    item.DataFields.FieldByName("PURCH_DEDUCT_CODE").Value = stok.PURCH_DEDUCT_CODE;
                    item.DataFields.FieldByName("SALE_DEDUCTION_PART1").Value = stok.SALE_DEDUCTION_PART1;
                    item.DataFields.FieldByName("SALE_DEDUCTION_PART2").Value = stok.SALE_DEDUCTION_PART2;
                    item.DataFields.FieldByName("PURCH_DEDUCTION_PART1").Value = stok.PURCH_DEDUCTION_PART1;
                    item.DataFields.FieldByName("PURCH_DEDUCTION_PART2").Value = stok.PURCH_DEDUCTION_PART2;
                    item.DataFields.FieldByName("TRACK_TYPE").Value = stok.TRACK_TYPE;
                    item.DataFields.FieldByName("LOCATION_TRACKING").Value = stok.LOCATION_TRACKING;
                    item.DataFields.FieldByName("VAT").Value = stok.VAT;
                    item.DataFields.FieldByName("SELVAT").Value = stok.SELVAT;
                    item.DataFields.FieldByName("RETURNVAT").Value = stok.RETURNVAT;
                    item.DataFields.FieldByName("SELPRVAT").Value = stok.SELPRVAT;
                    item.DataFields.FieldByName("RETURNPRVAT").Value = stok.RETURNPRVAT;
                    item.DataFields.FieldByName("DIST_LOT_UNITS").Value = stok.DIST_LOT_UNITS;
                    item.DataFields.FieldByName("COMB_LOT_UNITS").Value = stok.COMB_LOT_UNITS;
                    item.DataFields.FieldByName("LOTS_DIVISIBLE").Value = stok.LOTS_DIVISIBLE;
                    item.DataFields.FieldByName("ADDTAXPURCHBRWS").Value = stok.ADDTAXPURCHBRWS;
                    item.DataFields.FieldByName("ADDTAXSALESBRWS").Value = stok.ADDTAXSALESBRWS;
                    item.DataFields.FieldByName("MARKCODE").Value = stok.MARKCODE;
                    item.DataFields.FieldByName("UNITSET_CODE").Value = stok.UNITSET_CODE;


                    item.DataFields.FieldByName("DATE_MODIFIED").Value = stok.DATE_MODIFIED;
                    item.DataFields.FieldByName("HOUR_MODIFIED").Value = stok.HOUR_MODIFIED;
                    item.DataFields.FieldByName("MIN_MODIFIED").Value = stok.MIN_MODIFIED;
                    item.DataFields.FieldByName("SEC_MODIFIED").Value = stok.SEC_MODIFIED;

                    UnityObjects.Lines units_lines = item.DataFields.FieldByName("UNITS").Lines;
                    while (units_lines.Count > 0)
                    {
                        units_lines.DeleteLine(0);
                    }
                    units_lines.Clear();

                    foreach (var birimm in stok.UNITS.items)
                    {
                        units_lines.AppendLine();
                        units_lines[units_lines.Count - 1].FieldByName("UNIT_CODE").Value = birimm.UNIT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
                        units_lines[units_lines.Count - 1].FieldByName("CONV_FACT1").Value = birimm.CONV_FACT1;
                        units_lines[units_lines.Count - 1].FieldByName("CONV_FACT2").Value = birimm.CONV_FACT2;
                        //
                        units_lines[units_lines.Count - 1].FieldByName("WIDTH").Value = birimm.WIDTH;
                        units_lines[units_lines.Count - 1].FieldByName("LENGTH").Value = birimm.LENGTH;
                        units_lines[units_lines.Count - 1].FieldByName("HEIGHT").Value = birimm.HEIGHT;
                        units_lines[units_lines.Count - 1].FieldByName("AREA").Value = birimm.AREA;
                        units_lines[units_lines.Count - 1].FieldByName("VOLUME").Value = birimm.VOLUME;
                        units_lines[units_lines.Count - 1].FieldByName("WEIGHT").Value = birimm.WEIGHT;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_VOLUME").Value = birimm.GROSS_VOLUME;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_WEIGHT").Value = birimm.GROSS_WEIGHT;
                        //
                        units_lines[units_lines.Count - 1].FieldByName("WIDTH_CODE").Value = birimm.WIDTH_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("LENGTH_CODE").Value = birimm.LENGTH_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("HEIGHT_CODE").Value = birimm.HEIGHT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("AREA_CODE").Value = birimm.AREA_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("VOLUME_CODE").Value = birimm.VOLUME_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("WEIGHT_CODE").Value = birimm.WEIGHT_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_VOL_CODE").Value = birimm.GROSS_VOL_CODE;
                        units_lines[units_lines.Count - 1].FieldByName("GROSS_WGHT_CODE").Value = birimm.GROSS_WGHT_CODE;

                        if (birimm.BARCODE_LIST.items.Count() > 0)
                        {
                            UnityObjects.Lines barcode_list0 = units_lines[units_lines.Count - 1].FieldByName("BARCODE_LIST").Lines;
                            foreach (var brkd in birimm.BARCODE_LIST.items.OrderBy(s => s.LINENR))
                            {
                                barcode_list0.AppendLine();
                                barcode_list0[barcode_list0.Count - 1].FieldByName("BARCODE").Value = brkd.BARCODE;
                                //barcode_list0[barcode_list0.Count - 1].FieldByName("XML_ATTRIBUTE").Value = 1;
                            }
                        }

                    }



                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }

        public string[] CariKartiEkle(Logo.CARI.Root cari)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                    item.New();
                    item.DataFields.FieldByName("ACCOUNT_TYPE").Value = cari.ACCOUNT_TYPE;
                    item.DataFields.FieldByName("CODE").Value = cari.CODE;
                    item.DataFields.FieldByName("TITLE").Value = cari.TITLE;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = cari.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = cari.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = cari.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = cari.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = cari.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = cari.AUTH_CODE;
                    item.DataFields.FieldByName("TRADING_GRP").Value = cari.TRADING_GRP;
                    item.DataFields.FieldByName("PAYMENT_CODE").Value = cari.PAYMENT_CODE;
                    item.DataFields.FieldByName("ADDRESS1").Value = cari.ADDRESS1;
                    item.DataFields.FieldByName("ADDRESS2").Value = cari.ADDRESS2;
                    item.DataFields.FieldByName("COUNTRY_CODE").Value = cari.COUNTRY_CODE;
                    item.DataFields.FieldByName("COUNTRY").Value = cari.COUNTRY;
                    item.DataFields.FieldByName("CITY_CODE").Value = cari.CITY_CODE;
                    item.DataFields.FieldByName("CITY").Value = cari.CITY;
                    item.DataFields.FieldByName("TOWN_CODE").Value = cari.TOWN_CODE;
                    item.DataFields.FieldByName("TOWN").Value = cari.TOWN;
                    item.DataFields.FieldByName("DISTRICT_CODE").Value = cari.DISTRICT_CODE;
                    item.DataFields.FieldByName("DISTRICT").Value = cari.DISTRICT;
                    item.DataFields.FieldByName("POSTAL_CODE").Value = cari.POSTAL_CODE;

                    item.DataFields.FieldByName("CONTACT").Value = cari.CONTACT;
                    item.DataFields.FieldByName("CONTACT2").Value = cari.CONTACT2;
                    item.DataFields.FieldByName("CONTACT3").Value = cari.CONTACT3;
                    item.DataFields.FieldByName("E_MAIL").Value = cari.E_MAIL;
                    item.DataFields.FieldByName("E_MAIL2").Value = cari.E_MAIL2;
                    item.DataFields.FieldByName("E_MAIL3").Value = cari.E_MAIL3;
                    item.DataFields.FieldByName("CONTACT1_TEL").Value = cari.CONTACT1_TEL;
                    item.DataFields.FieldByName("CONTACT2_TEL").Value = cari.CONTACT2_TEL;
                    item.DataFields.FieldByName("CONTACT3_TEL").Value = cari.CONTACT3_TEL;
                    item.DataFields.FieldByName("TELEPHONE1").Value = cari.TELEPHONE1;
                    item.DataFields.FieldByName("TELEPHONE2").Value = cari.TELEPHONE2;

                    item.DataFields.FieldByName("FAX").Value = cari.FAX;
                    item.DataFields.FieldByName("PURCHBRWS").Value = cari.PURCHBRWS;
                    item.DataFields.FieldByName("SALESBRWS").Value = cari.SALESBRWS;
                    item.DataFields.FieldByName("IMPBRWS").Value = cari.IMPBRWS;
                    item.DataFields.FieldByName("EXPBRWS").Value = cari.EXPBRWS;
                    item.DataFields.FieldByName("FINBRWS").Value = cari.FINBRWS;


                    item.DataFields.FieldByName("RISK_TYPE1").Value = cari.RISK_TYPE1;
                    item.DataFields.FieldByName("RISK_TYPE2").Value = cari.RISK_TYPE2;
                    item.DataFields.FieldByName("RISK_TYPE3").Value = cari.RISK_TYPE3;
                    item.DataFields.FieldByName("RISK_TYPE4").Value = cari.RISK_TYPE4;
                    item.DataFields.FieldByName("RISK_TYPE5").Value = cari.RISK_TYPE5;
                    item.DataFields.FieldByName("RISK_TYPE6").Value = cari.RISK_TYPE6;
                    item.DataFields.FieldByName("RISK_TYPE7").Value = cari.RISK_TYPE7;
                    item.DataFields.FieldByName("RISK_TYPE8").Value = cari.RISK_TYPE8;



                    item.DataFields.FieldByName("ACC_RISK_LIMIT").Value = cari.ACC_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_ACC").Value = cari.ACTION_CREDHOLD_ACC;

                    item.DataFields.FieldByName("MY_CS_RISK_LIMIT").Value = cari.MY_CS_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_MY_CS").Value = cari.ACTION_CREDHOLD_MY_CS;

                    item.DataFields.FieldByName("CST_CS_RISK_LIMIT").Value = cari.CST_CS_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_CST_CS").Value = cari.ACTION_CREDHOLD_CST_CS;

                    item.DataFields.FieldByName("DESP_RISK_LIMIT").Value = cari.DESP_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_DESP").Value = cari.ACTION_CREDHOLD_DESP;

                    item.DataFields.FieldByName("ORD_RISK_LIMIT").Value = cari.ORD_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_ORD").Value = cari.ACTION_CREDHOLD_ORD;

                    item.DataFields.FieldByName("CST_CS_CIRO_RISK_LIMIT").Value = cari.CST_CS_CIRO_RISK_LIMIT;
                    item.DataFields.FieldByName("CST_CS_CIRO_RISK_OVER").Value = cari.CST_CS_CIRO_RISK_OVER;

                    item.DataFields.FieldByName("DESP_RISK_LIMIT_SUGG").Value = cari.DESP_RISK_LIMIT_SUGG;
                    item.DataFields.FieldByName("DESP_RISK_OVER_SUGG").Value = cari.DESP_RISK_OVER_SUGG;

                    item.DataFields.FieldByName("ORD_RISK_LIMIT_SUGG").Value = cari.ORD_RISK_LIMIT_SUGG;
                    item.DataFields.FieldByName("ORD_RISK_OVER_SUGG").Value = cari.ORD_RISK_OVER_SUGG;


                    item.DataFields.FieldByName("DUE_DATE_COUNT").Value = cari.DUE_DATE_COUNT;
                    item.DataFields.FieldByName("DUE_DATE_LIMIT").Value = cari.DUE_DATE_LIMIT;
                    item.DataFields.FieldByName("DUE_DATE_TRACK").Value = cari.DUE_DATE_TRACK;

                    item.DataFields.FieldByName("DUE_DATE_CONTOL2").Value = cari.DUE_DATE_CONTOL2;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL3").Value = cari.DUE_DATE_CONTOL3;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL4").Value = cari.DUE_DATE_CONTOL4;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL5").Value = cari.DUE_DATE_CONTOL5;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL6").Value = cari.DUE_DATE_CONTOL6;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL7").Value = cari.DUE_DATE_CONTOL7;



                    item.DataFields.FieldByName("PERSCOMPANY").Value = cari.PERSCOMPANY;
                    item.DataFields.FieldByName("TCKNO").Value = cari.TCKNO;
                    item.DataFields.FieldByName("NAME").Value = cari.NAME;
                    item.DataFields.FieldByName("SURNAME").Value = cari.SURNAME;
                    item.DataFields.FieldByName("TAX_OFFICE").Value = cari.TAX_OFFICE;
                    item.DataFields.FieldByName("TAX_OFFICE_CODE").Value = cari.TAX_OFFICE_CODE;
                    item.DataFields.FieldByName("TAX_ID").Value = cari.TAX_ID;
                    item.DataFields.FieldByName("ACCEPT_EINV").Value = cari.ACCEPT_EINV;
                    item.DataFields.FieldByName("POST_LABEL").Value = cari.POST_LABEL;
                    item.DataFields.FieldByName("SENDER_LABEL").Value = cari.SENDER_LABEL;
                    item.DataFields.FieldByName("GL_CODE").Value = cari.GL_CODE;



                    item.DataFields.FieldByName("DATE_CREATED").Value = cari.DATE_CREATED;
                    item.DataFields.FieldByName("HOUR_CREATED").Value = cari.HOUR_CREATED;
                    item.DataFields.FieldByName("MIN_CREATED").Value = cari.MIN_CREATED;
                    item.DataFields.FieldByName("SEC_CREATED").Value = cari.SEC_CREATED;
                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }
        public string[] CariKartiDuzenle(Logo.CARI.Root cari)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doAccountsRP);
                    item.Read(cari.INTERNAL_REFERENCE);
                    item.DataFields.FieldByName("ACCOUNT_TYPE").Value = cari.ACCOUNT_TYPE;
                    item.DataFields.FieldByName("CODE").Value = cari.CODE;
                    item.DataFields.FieldByName("TITLE").Value = cari.TITLE;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = cari.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = cari.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = cari.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = cari.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = cari.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = cari.AUTH_CODE;
                    item.DataFields.FieldByName("TRADING_GRP").Value = cari.TRADING_GRP;
                    item.DataFields.FieldByName("PAYMENT_CODE").Value = cari.PAYMENT_CODE;
                    item.DataFields.FieldByName("ADDRESS1").Value = cari.ADDRESS1;
                    item.DataFields.FieldByName("ADDRESS2").Value = cari.ADDRESS2;
                    item.DataFields.FieldByName("COUNTRY_CODE").Value = cari.COUNTRY_CODE;
                    item.DataFields.FieldByName("COUNTRY").Value = cari.COUNTRY;
                    item.DataFields.FieldByName("CITY_CODE").Value = cari.CITY_CODE;
                    item.DataFields.FieldByName("CITY").Value = cari.CITY;
                    item.DataFields.FieldByName("TOWN_CODE").Value = cari.TOWN_CODE;
                    item.DataFields.FieldByName("TOWN").Value = cari.TOWN;
                    item.DataFields.FieldByName("DISTRICT_CODE").Value = cari.DISTRICT_CODE;
                    item.DataFields.FieldByName("DISTRICT").Value = cari.DISTRICT;
                    item.DataFields.FieldByName("POSTAL_CODE").Value = cari.POSTAL_CODE;
                    item.DataFields.FieldByName("CONTACT").Value = cari.CONTACT;
                    item.DataFields.FieldByName("CONTACT2").Value = cari.CONTACT2;
                    item.DataFields.FieldByName("CONTACT3").Value = cari.CONTACT3;
                    item.DataFields.FieldByName("E_MAIL").Value = cari.E_MAIL;
                    item.DataFields.FieldByName("E_MAIL2").Value = cari.E_MAIL2;
                    item.DataFields.FieldByName("E_MAIL3").Value = cari.E_MAIL3;
                    item.DataFields.FieldByName("CONTACT1_TEL").Value = cari.CONTACT1_TEL;
                    item.DataFields.FieldByName("CONTACT2_TEL").Value = cari.CONTACT2_TEL;
                    item.DataFields.FieldByName("CONTACT3_TEL").Value = cari.CONTACT3_TEL;
                    item.DataFields.FieldByName("TELEPHONE1").Value = cari.TELEPHONE1;
                    item.DataFields.FieldByName("TELEPHONE2").Value = cari.TELEPHONE2;
                    item.DataFields.FieldByName("FAX").Value = cari.FAX;
                    item.DataFields.FieldByName("PURCHBRWS").Value = cari.PURCHBRWS;
                    item.DataFields.FieldByName("SALESBRWS").Value = cari.SALESBRWS;
                    item.DataFields.FieldByName("IMPBRWS").Value = cari.IMPBRWS;
                    item.DataFields.FieldByName("EXPBRWS").Value = cari.EXPBRWS;
                    item.DataFields.FieldByName("FINBRWS").Value = cari.FINBRWS;


                    item.DataFields.FieldByName("RISK_TYPE1").Value = cari.RISK_TYPE1;
                    item.DataFields.FieldByName("RISK_TYPE2").Value = cari.RISK_TYPE2;
                    item.DataFields.FieldByName("RISK_TYPE3").Value = cari.RISK_TYPE3;
                    item.DataFields.FieldByName("RISK_TYPE4").Value = cari.RISK_TYPE4;
                    item.DataFields.FieldByName("RISK_TYPE5").Value = cari.RISK_TYPE5;
                    item.DataFields.FieldByName("RISK_TYPE6").Value = cari.RISK_TYPE6;
                    item.DataFields.FieldByName("RISK_TYPE7").Value = cari.RISK_TYPE7;
                    item.DataFields.FieldByName("RISK_TYPE8").Value = cari.RISK_TYPE8;



                    item.DataFields.FieldByName("ACC_RISK_LIMIT").Value = cari.ACC_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_ACC").Value = cari.ACTION_CREDHOLD_ACC;

                    item.DataFields.FieldByName("MY_CS_RISK_LIMIT").Value = cari.MY_CS_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_MY_CS").Value = cari.ACTION_CREDHOLD_MY_CS;

                    item.DataFields.FieldByName("CST_CS_RISK_LIMIT").Value = cari.CST_CS_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_CST_CS").Value = cari.ACTION_CREDHOLD_CST_CS;

                    item.DataFields.FieldByName("DESP_RISK_LIMIT").Value = cari.DESP_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_DESP").Value = cari.ACTION_CREDHOLD_DESP;

                    item.DataFields.FieldByName("ORD_RISK_LIMIT").Value = cari.ORD_RISK_LIMIT;
                    item.DataFields.FieldByName("ACTION_CREDHOLD_ORD").Value = cari.ACTION_CREDHOLD_ORD;

                    item.DataFields.FieldByName("CST_CS_CIRO_RISK_LIMIT").Value = cari.CST_CS_CIRO_RISK_LIMIT;
                    item.DataFields.FieldByName("CST_CS_CIRO_RISK_OVER").Value = cari.CST_CS_CIRO_RISK_OVER;

                    item.DataFields.FieldByName("DESP_RISK_LIMIT_SUGG").Value = cari.DESP_RISK_LIMIT_SUGG;
                    item.DataFields.FieldByName("DESP_RISK_OVER_SUGG").Value = cari.DESP_RISK_OVER_SUGG;

                    item.DataFields.FieldByName("ORD_RISK_LIMIT_SUGG").Value = cari.ORD_RISK_LIMIT_SUGG;
                    item.DataFields.FieldByName("ORD_RISK_OVER_SUGG").Value = cari.ORD_RISK_OVER_SUGG;


                    item.DataFields.FieldByName("DUE_DATE_COUNT").Value = cari.DUE_DATE_COUNT;
                    item.DataFields.FieldByName("DUE_DATE_LIMIT").Value = cari.DUE_DATE_LIMIT;
                    item.DataFields.FieldByName("DUE_DATE_TRACK").Value = cari.DUE_DATE_TRACK;

                    item.DataFields.FieldByName("DUE_DATE_CONTOL2").Value = cari.DUE_DATE_CONTOL2;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL3").Value = cari.DUE_DATE_CONTOL3;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL4").Value = cari.DUE_DATE_CONTOL4;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL5").Value = cari.DUE_DATE_CONTOL5;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL6").Value = cari.DUE_DATE_CONTOL6;
                    item.DataFields.FieldByName("DUE_DATE_CONTOL7").Value = cari.DUE_DATE_CONTOL7;


                    item.DataFields.FieldByName("PERSCOMPANY").Value = cari.PERSCOMPANY;
                    item.DataFields.FieldByName("TCKNO").Value = cari.TCKNO;
                    item.DataFields.FieldByName("NAME").Value = cari.NAME;
                    item.DataFields.FieldByName("SURNAME").Value = cari.SURNAME;
                    item.DataFields.FieldByName("TAX_OFFICE").Value = cari.TAX_OFFICE;
                    item.DataFields.FieldByName("TAX_OFFICE_CODE").Value = cari.TAX_OFFICE_CODE;
                    item.DataFields.FieldByName("TAX_ID").Value = cari.TAX_ID;
                    item.DataFields.FieldByName("ACCEPT_EINV").Value = cari.ACCEPT_EINV;
                    item.DataFields.FieldByName("POST_LABEL").Value = cari.POST_LABEL;
                    item.DataFields.FieldByName("SENDER_LABEL").Value = cari.SENDER_LABEL;
                    item.DataFields.FieldByName("GL_CODE").Value = cari.GL_CODE;


                    item.DataFields.FieldByName("DATE_MODIFIED").Value = cari.DATE_MODIFIED;
                    item.DataFields.FieldByName("HOUR_MODIFIED").Value = cari.HOUR_MODIFIED;
                    item.DataFields.FieldByName("MIN_MODIFIED").Value = cari.MIN_MODIFIED;
                    item.DataFields.FieldByName("SEC_MODIFIED").Value = cari.SEC_MODIFIED;

                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }

        public string[] CariMuhasebeKoduEkle(Logo.MuhasebeHesapKarti.Root muhasebe)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doGLAccount);
                    item.New();
                    item.DataFields.FieldByName("CODE").Value = muhasebe.CODE;
                    item.DataFields.FieldByName("DESCRIPTION").Value = muhasebe.DESCRIPTION;
                    item.DataFields.FieldByName("DESCRIPTION2").Value = muhasebe.DESCRIPTION2;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = muhasebe.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = muhasebe.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = muhasebe.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = muhasebe.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = muhasebe.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = muhasebe.AUTH_CODE;
                    item.DataFields.FieldByName("RECORD_STATUS").Value = muhasebe.RECORD_STATUS;
                    item.DataFields.FieldByName("ACCOUNT_TYPE").Value = muhasebe.ACCOUNT_TYPE;
                    item.DataFields.FieldByName("ACCOUNT_CHAR").Value = muhasebe.ACCOUNT_CHAR;


                    item.DataFields.FieldByName("DATE_CREATED").Value = muhasebe.DATE_CREATED;
                    item.DataFields.FieldByName("HOUR_CREATED").Value = muhasebe.HOUR_CREATED;
                    item.DataFields.FieldByName("MIN_CREATED").Value = muhasebe.MIN_CREATED;
                    item.DataFields.FieldByName("SEC_CREATED").Value = muhasebe.SEC_CREATED;
                   
                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }
        public string[] CariMuhasebeKoduDuzenle(Logo.MuhasebeHesapKarti.Root muhasebe)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data item = UnityApp.NewDataObject(UnityObjects.DataObjectType.doGLAccount);
                    item.Read(muhasebe.INTERNAL_REFERENCE);
                    item.DataFields.FieldByName("CODE").Value = muhasebe.CODE;
                    item.DataFields.FieldByName("DESCRIPTION").Value = muhasebe.DESCRIPTION;
                    item.DataFields.FieldByName("DESCRIPTION2").Value = muhasebe.DESCRIPTION2;
                    item.DataFields.FieldByName("AUXIL_CODE").Value = muhasebe.AUXIL_CODE;
                    item.DataFields.FieldByName("AUXIL_CODE2").Value = muhasebe.AUXIL_CODE2;
                    item.DataFields.FieldByName("AUXIL_CODE3").Value = muhasebe.AUXIL_CODE3;
                    item.DataFields.FieldByName("AUXIL_CODE4").Value = muhasebe.AUXIL_CODE4;
                    item.DataFields.FieldByName("AUXIL_CODE5").Value = muhasebe.AUXIL_CODE5;
                    item.DataFields.FieldByName("AUTH_CODE").Value = muhasebe.AUTH_CODE;
                    item.DataFields.FieldByName("RECORD_STATUS").Value = muhasebe.RECORD_STATUS;
                    item.DataFields.FieldByName("ACCOUNT_TYPE").Value = muhasebe.ACCOUNT_TYPE;
                    item.DataFields.FieldByName("ACCOUNT_CHAR").Value = muhasebe.ACCOUNT_CHAR;



                    item.DataFields.FieldByName("DATE_MODIFIED").Value = muhasebe.DATE_MODIFIED;
                    item.DataFields.FieldByName("HOUR_MODIFIED").Value = muhasebe.HOUR_MODIFIED;
                    item.DataFields.FieldByName("MIN_MODIFIED").Value = muhasebe.MIN_MODIFIED;
                    item.DataFields.FieldByName("SEC_MODIFIED").Value = muhasebe.SEC_MODIFIED;

                    string geriDonecekDeger;
                    if (item.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, item.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < item.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(item.ValidateErrors[i].Error);//logo hatası
                        }

                        if (item.ErrorCode != 0)
                        {
                            sb.AppendLine(item.ErrorDesc);//logo nun döndürdüğü hata
                            sb.AppendLine(item.DBErrorDesc);//logo veritabanı hatası

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }


        public string[] SevkAdesiEkle(Logo.CariSevk.Root adres)
        {
            if (Baglan())
            {
                try
                {

                    UnityObjects.Data SevkAdresi = UnityApp.NewDataObject(UnityObjects.DataObjectType.doArpShipLic);
                    SevkAdresi.New();
                    SevkAdresi.DataFields.FieldByName("ARP_CODE").Value = adres.ARP_CODE;
                    SevkAdresi.DataFields.FieldByName("DESCRIPTION").Value = adres.DESCRIPTION;
                    SevkAdresi.DataFields.FieldByName("CLIENTREF").Value = adres.CLIENTREF;
                    SevkAdresi.DataFields.FieldByName("CODE").Value = adres.CODE;
                    SevkAdresi.DataFields.FieldByName("TITLE").Value = adres.TITLE;
                    SevkAdresi.DataFields.FieldByName("ADDRESS1").Value = adres.ADDRESS1;
                    SevkAdresi.DataFields.FieldByName("ADDRESS2").Value = adres.ADDRESS2;
                    SevkAdresi.DataFields.FieldByName("DISTRICT_CODE").Value = adres.DISTRICT_CODE;
                    SevkAdresi.DataFields.FieldByName("DISTRICT").Value = adres.DISTRICT;
                    SevkAdresi.DataFields.FieldByName("TOWN").Value = adres.TOWN;
                    SevkAdresi.DataFields.FieldByName("TOWN_CODE").Value = adres.TOWN_CODE;
                    SevkAdresi.DataFields.FieldByName("CITY").Value = adres.CITY;
                    SevkAdresi.DataFields.FieldByName("CITY_CODE").Value = adres.CITY_CODE;
                    SevkAdresi.DataFields.FieldByName("COUNTRY").Value = adres.COUNTRY;
                    SevkAdresi.DataFields.FieldByName("COUNTRY_CODE").Value = adres.COUNTRY_CODE;
                    SevkAdresi.DataFields.FieldByName("POSTAL_CODE").Value = adres.POSTAL_CODE;
                    SevkAdresi.DataFields.FieldByName("TELEPHONE1").Value = adres.TELEPHONE1;
                    SevkAdresi.DataFields.FieldByName("TELEPHONE2").Value = adres.TELEPHONE2;
                    SevkAdresi.DataFields.FieldByName("FAX").Value = adres.FAX;
                    SevkAdresi.DataFields.FieldByName("TAX_NR").Value = adres.TAX_NR;
                    SevkAdresi.DataFields.FieldByName("TAX_OFFICE").Value = adres.TAX_OFFICE;
                    SevkAdresi.DataFields.FieldByName("TRADING_GRP").Value = adres.TRADING_GRP;
                    SevkAdresi.DataFields.FieldByName("VAT_NR").Value = adres.VAT_NR;
                    SevkAdresi.DataFields.FieldByName("DATE_CREATED").Value = DateTime.Now;
                    SevkAdresi.DataFields.FieldByName("HOUR_CREATED").Value = DateTime.Now.Hour;
                    SevkAdresi.DataFields.FieldByName("MIN_CREATED").Value = DateTime.Now.Minute;
                    SevkAdresi.DataFields.FieldByName("SEC_CREATED").Value = DateTime.Now.Second;
                    SevkAdresi.DataFields.FieldByName("XBUFS").Value = adres.XBUFS;
                    SevkAdresi.DataFields.FieldByName("INCHANGE").Value = adres.INCHANGE;
                    SevkAdresi.DataFields.FieldByName("LONGITUDE").Value = adres.LONGITUDE;
                    SevkAdresi.DataFields.FieldByName("LATITUDE").Value = adres.LATITUDE;
                    SevkAdresi.DataFields.FieldByName("CITY_ID").Value = adres.CITY_ID;
                    SevkAdresi.DataFields.FieldByName("TOWN_ID").Value = adres.TOWN_ID;
                    SevkAdresi.DataFields.FieldByName("DEFAULT_FLAG").Value = adres.DEFAULT_FLAG;
                    SevkAdresi.DataFields.FieldByName("PERSCOMPANY").Value = adres.PERSCOMPANY;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME1").Value = adres.SHIP_BEG_TIME1;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME2").Value = adres.SHIP_BEG_TIME2;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME3").Value = adres.SHIP_BEG_TIME3;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME1").Value = adres.SHIP_END_TIME1;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME2").Value = adres.SHIP_END_TIME2;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME3").Value = adres.SHIP_END_TIME3;
                    SevkAdresi.DataFields.FieldByName("RECORD_STATUS").Value = adres.RECORD_STATUS;
                    SevkAdresi.DataFields.FieldByName("EMAIL_ADDR").Value = adres.EMAIL_ADDR;
                    SevkAdresi.DataFields.FieldByName("TCKNO").Value = adres.TCKNO;
                    SevkAdresi.DataFields.FieldByName("NAME").Value = adres.NAME;
                    SevkAdresi.DataFields.FieldByName("SURNAME").Value = adres.SURNAME;

                    string geriDonecekDeger;
                    if (SevkAdresi.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(SevkAdresi.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, SevkAdresi.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < SevkAdresi.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(SevkAdresi.ValidateErrors[i].Error);
                        }

                        if (SevkAdresi.ErrorCode != 0)
                        {
                            sb.AppendLine(SevkAdresi.ErrorDesc);
                            sb.AppendLine(SevkAdresi.DBErrorDesc);

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }

        public string[] SevkAdesiDuzenle(Logo.CariSevk.Root adres)
        {
            if (Baglan())
            {
                try
                {
                    UnityObjects.Data SevkAdresi = UnityApp.NewDataObject(UnityObjects.DataObjectType.doArpShipLic);
                    SevkAdresi.Read(adres.INTERNAL_REFERENCE);
                    SevkAdresi.DataFields.FieldByName("ARP_CODE").Value = adres.ARP_CODE;
                    SevkAdresi.DataFields.FieldByName("DESCRIPTION").Value = adres.DESCRIPTION;
                    SevkAdresi.DataFields.FieldByName("CLIENTREF").Value = adres.CLIENTREF;
                    SevkAdresi.DataFields.FieldByName("CODE").Value = adres.CODE;
                    SevkAdresi.DataFields.FieldByName("TITLE").Value = adres.TITLE;
                    SevkAdresi.DataFields.FieldByName("ADDRESS1").Value = adres.ADDRESS1;
                    SevkAdresi.DataFields.FieldByName("ADDRESS2").Value = adres.ADDRESS2;
                    SevkAdresi.DataFields.FieldByName("DISTRICT_CODE").Value = adres.DISTRICT_CODE;
                    SevkAdresi.DataFields.FieldByName("DISTRICT").Value = adres.DISTRICT;
                    SevkAdresi.DataFields.FieldByName("TOWN").Value = adres.TOWN;
                    SevkAdresi.DataFields.FieldByName("TOWN_CODE").Value = adres.TOWN_CODE;
                    SevkAdresi.DataFields.FieldByName("CITY").Value = adres.CITY;
                    SevkAdresi.DataFields.FieldByName("CITY_CODE").Value = adres.CITY_CODE;
                    SevkAdresi.DataFields.FieldByName("COUNTRY").Value = adres.COUNTRY;
                    SevkAdresi.DataFields.FieldByName("COUNTRY_CODE").Value = adres.COUNTRY_CODE;
                    SevkAdresi.DataFields.FieldByName("POSTAL_CODE").Value = adres.POSTAL_CODE;
                    SevkAdresi.DataFields.FieldByName("TELEPHONE1").Value = adres.TELEPHONE1;
                    SevkAdresi.DataFields.FieldByName("TELEPHONE2").Value = adres.TELEPHONE2;
                    SevkAdresi.DataFields.FieldByName("FAX").Value = adres.FAX;
                    SevkAdresi.DataFields.FieldByName("TAX_NR").Value = adres.TAX_NR;
                    SevkAdresi.DataFields.FieldByName("TAX_OFFICE").Value = adres.TAX_OFFICE;
                    SevkAdresi.DataFields.FieldByName("TRADING_GRP").Value = adres.TRADING_GRP;
                    SevkAdresi.DataFields.FieldByName("VAT_NR").Value = adres.VAT_NR;
                    SevkAdresi.DataFields.FieldByName("DATE_CREATED").Value = DateTime.Now;
                    SevkAdresi.DataFields.FieldByName("HOUR_CREATED").Value = DateTime.Now.Hour;
                    SevkAdresi.DataFields.FieldByName("MIN_CREATED").Value = DateTime.Now.Minute;
                    SevkAdresi.DataFields.FieldByName("SEC_CREATED").Value = DateTime.Now.Second;
                    SevkAdresi.DataFields.FieldByName("XBUFS").Value = adres.XBUFS;
                    SevkAdresi.DataFields.FieldByName("INCHANGE").Value = adres.INCHANGE;
                    SevkAdresi.DataFields.FieldByName("LONGITUDE").Value = adres.LONGITUDE;
                    SevkAdresi.DataFields.FieldByName("LATITUDE").Value = adres.LATITUDE;
                    SevkAdresi.DataFields.FieldByName("CITY_ID").Value = adres.CITY_ID;
                    SevkAdresi.DataFields.FieldByName("TOWN_ID").Value = adres.TOWN_ID;
                    SevkAdresi.DataFields.FieldByName("DEFAULT_FLAG").Value = adres.DEFAULT_FLAG;
                    SevkAdresi.DataFields.FieldByName("PERSCOMPANY").Value = adres.PERSCOMPANY;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME1").Value = adres.SHIP_BEG_TIME1;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME2").Value = adres.SHIP_BEG_TIME2;
                    SevkAdresi.DataFields.FieldByName("SHIP_BEG_TIME3").Value = adres.SHIP_BEG_TIME3;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME1").Value = adres.SHIP_END_TIME1;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME2").Value = adres.SHIP_END_TIME2;
                    SevkAdresi.DataFields.FieldByName("SHIP_END_TIME3").Value = adres.SHIP_END_TIME3;
                    SevkAdresi.DataFields.FieldByName("RECORD_STATUS").Value = adres.RECORD_STATUS;
                    SevkAdresi.DataFields.FieldByName("EMAIL_ADDR").Value = adres.EMAIL_ADDR;
                    SevkAdresi.DataFields.FieldByName("TCKNO").Value = adres.TCKNO;
                    SevkAdresi.DataFields.FieldByName("NAME").Value = adres.NAME;
                    SevkAdresi.DataFields.FieldByName("SURNAME").Value = adres.SURNAME;

                    string geriDonecekDeger;
                    if (SevkAdresi.Post())
                    {
                        geriDonecekDeger = "true";
                        int logicalref = Convert.ToInt32(SevkAdresi.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString());

                        return new string[] { geriDonecekDeger, SevkAdresi.DataFields.FieldByName("INTERNAL_REFERENCE").Value.ToString() };
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < SevkAdresi.ValidateErrors.Count; i++)
                        {
                            sb.AppendLine(SevkAdresi.ValidateErrors[i].Error);
                        }

                        if (SevkAdresi.ErrorCode != 0)
                        {
                            sb.AppendLine(SevkAdresi.ErrorDesc);
                            sb.AppendLine(SevkAdresi.DBErrorDesc);

                        }
                        geriDonecekDeger = sb.ToString();
                        return new string[] { geriDonecekDeger };
                    }
                }
                catch (Exception ex)
                {

                    return new string[] { ex.ToString() };
                }
            }
            else
            {
                return new string[] { "Obje Login Hatası!" };
            }
        }

    }

}
