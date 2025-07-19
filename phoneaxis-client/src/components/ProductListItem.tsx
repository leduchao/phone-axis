import { Box, Typography } from "@mui/material";
import { ROUTES } from "../routes";

interface ProductItemProps {
  image: string;
  name: string;
  originalPrice: number;
  discountPercentage?: number;
}

const ProductListItem = ({
  image,
  name,
  originalPrice,
  discountPercentage,
}: ProductItemProps) => {
  return (
    <Box
      component={"a"}
      href={`${ROUTES.Shop}/${name}`}
      display={"flex"}
      justifyContent={"center"}
      alignItems={"center"}
      flexDirection={"column"}
      sx={{ textDecoration: "none", color: "black" }}
    >
      <Box component={"img"} src={`${image}`} height={"300px"}></Box>
      <Typography>{name}</Typography>
      <Typography>$ {originalPrice} USD</Typography>
      {/* <Typography>$ {promotionalPrice} USD</Typography> */}
      {discountPercentage && <Typography>{discountPercentage}%</Typography>}
    </Box>
  );
};

export default ProductListItem;
