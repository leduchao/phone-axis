import { ArrowForward } from "@mui/icons-material";
import { Box, Button, Divider, Grid, Typography } from "@mui/material";
import ProductListItem from "./ProductListItem";
import { ROUTES } from "../routes";
import { ProductItem } from "../models/product-item";

const ProductList = ({
  products,
  title,
  hasButton = false,
  buttonText,
}: {
  products: ProductItem[];
  title: string;
  hasButton?: boolean;
  buttonText?: string;
}) => {
  return (
    <Box>
      <Box display={"flex"} justifyContent={"space-between"}>
        <Typography variant="h4">{title}</Typography>
        {hasButton && (
          <Button href={`${ROUTES.Shop}`}>
            {buttonText} <ArrowForward sx={{ ml: 1 }}></ArrowForward>
          </Button>
        )}
      </Box>

      <Divider sx={{ my: 2 }}></Divider>

      <Grid container columns={{ xs: 2, md: 4 }} spacing={3}>
        {products.map((item) => (
          <Grid size={1}>
            <ProductListItem
              image={`${item.image}`}
              name={`${item.name}`}
              originalPrice={item.originalPrice}
              discountPercentage={item.discountPercentage}
            ></ProductListItem>
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};

export default ProductList;
