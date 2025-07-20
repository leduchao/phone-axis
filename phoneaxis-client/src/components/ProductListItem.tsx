import { Box, Chip, Typography } from "@mui/material";
import { ROUTES } from "../routes";

const ProductListItem = ({
  image,
  name,
  originalPrice,
  discountPercentage,
}: {
  image: string;
  name: string;
  originalPrice: number;
  discountPercentage?: number;
}) => {
  const getFinalPrice = () => {
    return !discountPercentage || discountPercentage === 0
      ? originalPrice
      : originalPrice - originalPrice * (discountPercentage / 100);
  };
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
      <Box
        component={"img"}
        src={`${image}`}
        height={"400px"}
        borderRadius={1}
        mb={2}
      ></Box>
      <Typography>{name}</Typography>
      <Box display={"flex"} textAlign={"center"}>
        <Typography mr={1}>$ {getFinalPrice()} USD</Typography>
        {discountPercentage && (
          <Box display={"flex"}>
            <Typography
              color="gray"
              sx={{ textDecoration: "line-through" }}
              mr={1}
            >
              $ {originalPrice} USD
            </Typography>{" "}
            <Chip
              size="small"
              label={`${discountPercentage}%`}
              color="error"
            ></Chip>
          </Box>
        )}
      </Box>
    </Box>
  );
};

export default ProductListItem;
