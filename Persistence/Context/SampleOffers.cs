using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public static class SampleOffers
    {
        public static void SeedSampleOffers(ModelBuilder modelBuilder)
        {
            var offers = new List<Offer>();
            var random = new Random(42); // Fixed seed for consistent results

            // Sample data for different categories
            var travelOffers = new[]
            {
                ("المسافر", "خصم على حجوزات الفنادق عبر تطبيق المسافر", "أمانة منطقة الرياض", "Riyadh Region Municipality"),
                ("طيران ناس", "خصم على تذاكر الطيران الداخلي", "طيران ناس", "Flynas"),
                ("الخطوط السعودية", "خصم على الرحلات الدولية", "الخطوط السعودية", "Saudi Airlines"),
                ("فندق الفيصلية", "خصم على الإقامة في فندق الفيصلية", "فندق الفيصلية", "Al Faisaliah Hotel"),
                ("أجنحة الرياض", "خصم على حجوزات الأجنحة الفندقية", "أجنحة الرياض", "Riyadh Suites"),
                ("رحلات الحج", "خصم على رحلات الحج والعمرة", "مؤسسة الحج", "Hajj Foundation"),
                ("سياحة جدة", "خصم على الجولات السياحية في جدة", "هيئة السياحة", "Tourism Authority"),
                ("فندق الماريوت", "خصم على الإقامة في فندق الماريوت", "فندق الماريوت", "Marriott Hotel"),
                ("رحلات الطائف", "خصم على رحلات الطائف الصيفية", "شركة الطائف للسياحة", "Taif Tourism Company"),
                ("فندق الهيلتون", "خصم على الإقامة في فندق الهيلتون", "فندق الهيلتون", "Hilton Hotel")
            };

            var healthOffers = new[]
            {
                ("مستشفى المملكة", "خصم على الاستشارات الطبية والفحوصات", "مستشفى المملكة", "Kingdom Hospital"),
                ("عيادة الأسنان", "خصم على علاجات الأسنان", "عيادة الأسنان المتقدمة", "Advanced Dental Clinic"),
                ("مستشفى الملك فهد", "خصم على العمليات الجراحية", "مستشفى الملك فهد", "King Fahd Hospital"),
                ("صيدلية النهدي", "خصم على الأدوية والمستلزمات الطبية", "صيدلية النهدي", "Nahdi Pharmacy"),
                ("عيادة العيون", "خصم على فحوصات العيون", "عيادة العيون المتخصصة", "Specialized Eye Clinic"),
                ("مستشفى الملك خالد", "خصم على الخدمات الطبية", "مستشفى الملك خالد", "King Khalid Hospital"),
                ("عيادة الأطفال", "خصم على استشارات الأطفال", "عيادة الأطفال المتخصصة", "Specialized Children Clinic"),
                ("مستشفى الملك عبدالعزيز", "خصم على الفحوصات الطبية", "مستشفى الملك عبدالعزيز", "King Abdulaziz Hospital"),
                ("عيادة الجلدية", "خصم على علاجات الجلد", "عيادة الجلدية المتقدمة", "Advanced Dermatology Clinic"),
                ("مستشفى الملك سلمان", "خصم على الخدمات الطبية المتخصصة", "مستشفى الملك سلمان", "King Salman Hospital")
            };

            var bankingOffers = new[]
            {
                ("بنك الجزيرة", "خصم على الخدمات المصرفية والاستثمارية", "بنك الجزيرة", "AlJazira Bank"),
                ("البنك الأهلي", "خصم على القروض الشخصية", "البنك الأهلي التجاري", "National Commercial Bank"),
                ("بنك الراجحي", "خصم على خدمات الاستثمار", "بنك الراجحي", "Al Rajhi Bank"),
                ("بنك ساب", "خصم على البطاقات الائتمانية", "بنك ساب", "SABB Bank"),
                ("البنك السعودي الفرنسي", "خصم على الخدمات المصرفية", "البنك السعودي الفرنسي", "Saudi French Bank"),
                ("بنك الإنماء", "خصم على التمويل العقاري", "بنك الإنماء", "Alinma Bank"),
                ("بنك الرياض", "خصم على الخدمات المصرفية الرقمية", "بنك الرياض", "Riyad Bank"),
                ("البنك السعودي للاستثمار", "خصم على خدمات الاستثمار", "البنك السعودي للاستثمار", "Saudi Investment Bank"),
                ("بنك الخليج", "خصم على الخدمات المصرفية", "بنك الخليج", "Gulf Bank"),
                ("البنك العربي الوطني", "خصم على القروض التجارية", "البنك العربي الوطني", "Arab National Bank")
            };

            var generalOffers = new[]
            {
                ("مطعم اللوفر", "خصم على وجبات الطعام والشراب", "مطعم اللوفر", "Louvre Restaurant"),
                ("مطعم البيك", "خصم على الوجبات السريعة", "مطعم البيك", "Al Baik Restaurant"),
                ("كافيه ستاربكس", "خصم على المشروبات الساخنة", "ستاربكس", "Starbucks"),
                ("مطعم كنتاكي", "خصم على الوجبات السريعة", "كنتاكي", "KFC"),
                ("مطعم ماكدونالدز", "خصم على الوجبات السريعة", "ماكدونالدز", "McDonald's"),
                ("مطعم بيتزا هت", "خصم على البيتزا", "بيتزا هت", "Pizza Hut"),
                ("مطعم دومينوز", "خصم على البيتزا والوجبات", "دومينوز", "Domino's"),
                ("مطعم هارديز", "خصم على الوجبات السريعة", "هارديز", "Hardee's"),
                ("مطعم شوبارد", "خصم على الوجبات الفرنسية", "شوبارد", "Chopard"),
                ("مطعم نادين", "خصم على الوجبات اللبنانية", "مطعم نادين", "Nadine Restaurant")
            };

            var shoppingOffers = new[]
            {
                ("صالون الجمال", "خصم على خدمات التجميل والعناية بالبشرة", "صالون الجمال", "Beauty Salon"),
                ("متجر إيكيا", "خصم على الأثاث المنزلي", "إيكيا", "IKEA"),
                ("متجر كارفور", "خصم على البقالة والأدوات المنزلية", "كارفور", "Carrefour"),
                ("متجر هوم سنتر", "خصم على الأدوات المنزلية", "هوم سنتر", "Home Center"),
                ("متجر إكس ترا", "خصم على الأجهزة الإلكترونية", "إكس ترا", "Extra"),
                ("متجر جرير", "خصم على الكتب والأدوات المكتبية", "جرير", "Jarir"),
                ("متجر العثيم", "خصم على البقالة", "العثيم", "Al Othaim"),
                ("متجر بنده", "خصم على البقالة والأدوات المنزلية", "بنده", "Panda"),
                ("متجر لولو", "خصم على البقالة", "لولو هايبرماركت", "Lulu Hypermarket"),
                ("متجر ساكو", "خصم على الأدوات المنزلية", "ساكو", "SACO")
            };

            // Create offers for each category
            var allOffers = new[]
            {
                (travelOffers, 4), // سفر وسياحة
                (healthOffers, 3), // صحة وطب
                (bankingOffers, 2), // خدمات مصرفيه
                (generalOffers, 1), // عروض متنوعة
                (shoppingOffers, 5) // تسوق وبيع
            };

            var offerId = 1;
            var dependentIds = new int?[] { 1, 2, 3, 4, 5, 6, 7, null }; // Different dependent types
            var discountTypes = new[] { 1, 2, 3, 4 }; // Different discount types
            var discountValues = new[] { "10", "15", "20", "25", "30", "40", "50", "عرض خاص", "مجاني", "مبلغ ثابت" };

            foreach (var (categoryOffers, categoryId) in allOffers)
            {
                foreach (var (title, description, orgName, orgNameEnglish) in categoryOffers)
                {
                    var discountTypeId = discountTypes[random.Next(discountTypes.Length)];
                    var discountValue = discountValues[random.Next(discountValues.Length)];
                    var dependentId = dependentIds[random.Next(dependentIds.Length)];
                    var rating = Math.Round((decimal)(random.NextDouble() * 2 + 3), 1); // Rating between 3.0 and 5.0
                    var ratingCount = random.Next(50, 500);
                    var currentUses = random.Next(10, 1000);

                    var validFrom = DateTime.Now.AddDays(-random.Next(0, 30));
                    var validUntil = validFrom.AddDays(random.Next(30, 365));

                    offers.Add(new Offer
                    {
                        Id = offerId++,
                        Title = title,
                        Description = description,
                        DiscountTypeId = discountTypeId,
                        DiscountValue = discountValue,
                        CreatedAt = DateTime.Now.AddDays(-random.Next(0, 60)),
                        ValidFrom = validFrom,
                        ValidUntil = validUntil,
                    IsActive = true,
                        CategoryId = categoryId,
                      
                        OrganizationName = orgName,
                        OrganizationNameEnglish = orgNameEnglish,
                        DirectionsUrl = $"https://maps.google.com/?q={title.Replace(" ", "+")}",
                        Rating = rating,
                        RatingCount = ratingCount,
                        ImageUrl = $"https://example.com/images/{title.Replace(" ", "-").ToLower()}.jpg",
                        Name = title,
                        CurrentUses = currentUses,
                        TermsAndConditions = $"صالح على {description.Split("على")[1]?.Split(".")[0] ?? "الخدمة المحددة"}. يجب الحجز مسبقاً."
                    });
                }
            }                                                                                                                       

            modelBuilder.Entity<Offer>().HasData(offers.ToArray());

            // Seed many-to-many relationships for Offer-Platform
            var platformRelationships = new List<object>();
            for (int i = 1; i <= 50; i++)
            {
                // Each offer gets 1-3 random platforms
                var platformCount = random.Next(1, 4);
                var selectedPlatforms = new HashSet<int>();
                while (selectedPlatforms.Count < platformCount)
                {
                    selectedPlatforms.Add(random.Next(1, 6)); // Platforms 1-5
                }
                
                foreach (var platformId in selectedPlatforms)
                {
                    platformRelationships.Add(new { OffersId = i, PlatformsId = platformId });
                }
            }
            modelBuilder.Entity("OfferOfferPlatform").HasData(platformRelationships.ToArray());

            // Seed many-to-many relationships for Offer-SharingMethod
            var sharingMethodRelationships = new List<object>();
            for (int i = 1; i <= 50; i++)
            {
                // Each offer gets 1-3 random sharing methods
                var methodCount = random.Next(1, 4);
                var selectedMethods = new HashSet<int>();
                while (selectedMethods.Count < methodCount)
                {
                    selectedMethods.Add(random.Next(1, 6)); // Methods 1-5
                }
                
                foreach (var methodId in selectedMethods)
                {
                    sharingMethodRelationships.Add(new { OffersId = i, SharingMethodsId = methodId });
                }
            }
            modelBuilder.Entity("OfferOfferSharingMethod").HasData(sharingMethodRelationships.ToArray());

            // Seed many-to-many relationships for Offer-Location
            var locationRelationships = new List<object>();
            for (int i = 1; i <= 50; i++)
            {
                // Each offer gets 1-3 random locations
                var locationCount = random.Next(1, 4);
                var selectedLocations = new HashSet<int>();
                while (selectedLocations.Count < locationCount)
                {
                    selectedLocations.Add(random.Next(1, 11)); // Locations 1-10
                }
                
                foreach (var locationId in selectedLocations)
                {
                    locationRelationships.Add(new { OffersId = i, LocationsId = locationId });
                }
            }
            modelBuilder.Entity("OfferOfferLocation").HasData(locationRelationships.ToArray());
        }
    }
}