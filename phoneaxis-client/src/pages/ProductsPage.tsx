import Grid from "@mui/material/Grid";
import { AppConstants } from "../constants/app-constants";
import { ProductItem } from "../models/product-item";
import ProductListItem from "../components/ProductListItem";

const products: ProductItem[] = [
  {
    image: `${AppConstants.PHONE_IMAGE}`,
    name: "Samsung Galaxy S21",
    originalPrice: 19.99,
    discountPercentage: 50,
  },
  {
    image: `${AppConstants.PHONE_IMAGE}`,
    name: "Samsung Galaxy S21",
    originalPrice: 19.99,
    discountPercentage: 50,
  },
  {
    image: `${AppConstants.PHONE_IMAGE}`,
    name: "Samsung Galaxy S21",
    originalPrice: 19.99,
    discountPercentage: 50,
  },
  {
    image: `${AppConstants.PHONE_IMAGE}`,
    name: "Samsung Galaxy S21",
    originalPrice: 19.99,
    discountPercentage: 50,
  },
  {
    image: `${AppConstants.PHONE_IMAGE}`,
    name: "Samsung Galaxy S21",
    originalPrice: 19.99,
    discountPercentage: 50,
  },
];

const ProductsPage = () => {
  return (
    <Grid
      container
      spacing={{ xs: 2, sm: 3 }}
      columns={{ xs: 1, sm: 12, md: 12 }}
    >
      {products.map((product, index) => (
        <Grid size={{ xs: 1, sm: 4, md: 3 }} key={index}>
          <ProductListItem
            image={`${product.image}`}
            name={`${product.name}`}
            originalPrice={product.originalPrice}
          />
        </Grid>
      ))}
    </Grid>
  );
};

export default ProductsPage;
