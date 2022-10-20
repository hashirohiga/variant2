using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TestVariant2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<ProductMaterial> _productMaterialList;

        public List<ProductMaterial> ProductMaterialList
        {
            get { return _productMaterialList; }
            set { _productMaterialList = value; }
        }
        public MainWindowViewModel()
        {
            using (SEROV2Context db = new SEROV2Context ())
            {
                ProductMaterialList = db.ProductMaterials
                    .Include(m => m.Material)
                    .Include(p => p.Product)
                    .ThenInclude(pt => pt.ProductType).ToList();
            }
        }

    }
}
