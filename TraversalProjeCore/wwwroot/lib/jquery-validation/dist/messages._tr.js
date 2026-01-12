/*
 * Translated default messages for the jQuery validation plugin.
 * Locale: TR (Turkish; Türkçe)
 */
(function ($) {
	$.extend($.validator.messages, {
		required: "Bu alanın doldurulması zorunludur.",
		remote: "Lütfen bu alanı düzeltin.",
		email: "Lütfen geçerli bir e-posta adresi giriniz.",
		url: "Lütfen geçerli bir web adresi (URL) giriniz.",
		date: "Lütfen geçerli bir tarih giriniz.",
		dateISO: "Lütfen geçerli bir tarih giriniz(ISO formatında).",
		number: "Lütfen geçerli bir sayı giriniz.",
		digits: "Lütfen sadece rakamlarla giriş yapınız.",
		creditcard: "Lütfen geçerli bir kredi kartı numarası giriniz.",
		equalTo: "Lütfen aynı değeri tekrar giriniz.",
		extension: "Lütfen geçerli uzantılı bir dosya seçiniz.",
		maxlength: $.validator.format("Lütfen en fazla {0} karakter uzunluğunda değer giriniz."),
		minlength: $.validator.format("Lütfen en az {0} karakter uzunluğunda değer giriniz."),
		rangelength: $.validator.format("Lütfen en az {0} ve en fazla {1} karakter uzunluğunda değer giriniz."),
		range: $.validator.format("Lütfen {0} ile {1} arasında bir değer giriniz."),
		max: $.validator.format("Lütfen {0} değerinden küçük ya da eşit bir değer giriniz."),
		min: $.validator.format("Lütfen {0} değerinden büyük ya da eşit bir değer giriniz.")
	});
}(jQuery));