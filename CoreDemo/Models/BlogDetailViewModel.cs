namespace CoreDemo.Models
{

	//Controller dan view yani cshtml birden fazla veri göndermek istiyorum, cshtml de zaten modelim ne olacğaını belirtiyorduk, controller da da zaten ne göndericeğimi ben seçiyorum
	// peki her şey tamam eğer blog ile kategoriler birbirne bağlı olmasa yine olur muydu iklişki olmasa
	// tabi ki olurdu bu onunla alakalı bir durum değil
	public class BlogDetailViewModel
	{
		public BlogDetailViewModel()
		{
			this.BlogDetail = new EntityLayer.Concrete.Blog();
			// o yüzden boş bir liste olarak oluşturdum içi boş
			this.CategoryList = new List<EntityLayer.Concrete.Category>(); //bunu new yapman gerek çünkü bunun içine değer atarken null hatası alırsın
		}
		public EntityLayer.Concrete.Blog BlogDetail { get; set; }
		public List<EntityLayer.Concrete.Category> CategoryList { get; set; }
		
	}
}
