import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import { AppConstants } from "../constants/app-constants";
import { ProductItem } from "../models/product-item";
import ProductListItem from "../components/ProductListItem";

const products: ProductItem[] = [
  {
    title: "Samsung Galaxy S21",
    description:
      "Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica",
    promotionalPrice: 9.99,
    originalPrice: 19.99,
    discountPercentage: 50,
    imageUrl: `${AppConstants.PHONE_IMAGE}`,
  },
  {
    title: "Samsung Galaxy S21",
    description:
      "Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica",
    promotionalPrice: 9.99,
    originalPrice: 19.99,
    discountPercentage: 50,
    imageUrl: `${AppConstants.PHONE_IMAGE}`,
  },
  {
    title: "Samsung Galaxy S21",
    description:
      "Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica",
    promotionalPrice: 9.99,
    originalPrice: 19.99,
    discountPercentage: 50,
    imageUrl: `${AppConstants.PHONE_IMAGE}`,
  },
  {
    title: "Samsung Galaxy S21",
    description:
      "Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica",
    promotionalPrice: 9.99,
    originalPrice: 19.99,
    discountPercentage: 50,
    imageUrl: `${AppConstants.PHONE_IMAGE}`,
  },
  {
    title: "Samsung Galaxy S21",
    description:
      "Lizards are a widespread group of squamate reptiles, with over 6,000 species, ranging across all continents except Antarctica",
    promotionalPrice: 9.99,
    originalPrice: 19.99,
    discountPercentage: 50,
    imageUrl: `${AppConstants.PHONE_IMAGE}`,
  },
];

const ProductsPage = () => {
  const addToCart = (product: ProductItem) => {
    alert(`Add to cart: ${product.title}`);
  };

  const buyNow = (product: ProductItem) => {
    alert(`Buy now: ${product.title}`);
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <Grid
        container
        spacing={{ xs: 2, sm: 3 }}
        columns={{ xs: 1, sm: 12, md: 12 }}
      >
        {products.map((product, index) => (
          <Grid size={{ xs: 1, sm: 4, md: 3 }} key={index}>
            <ProductListItem
              {...product}
              onAddToCart={() => addToCart(product)}
              onBuyNow={() => buyNow(product)}
            />
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};

export default ProductsPage;
