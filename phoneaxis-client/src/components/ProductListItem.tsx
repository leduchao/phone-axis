import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Chip,
  Typography,
} from "@mui/material";
import { AppConstants } from "../constants/app-constants";

interface ProductItemProps {
  title: string;
  description: string;
  promotionalPrice: number;
  originalPrice?: number;
  discountPercentage?: number;
  imageUrl?: string;
  onAddToCart?: () => void;
  onBuyNow?: () => void;
}

const ProductListItem = ({
  title,
  description,
  promotionalPrice,
  originalPrice,
  discountPercentage,
  imageUrl,
  onAddToCart = () => {},
  onBuyNow = () => {},
}: ProductItemProps) => {
  return (
    <Card sx={{ width: "100%", boxShadow: 12 }}>
      <CardMedia
        sx={{ height: 250 }}
        image={imageUrl || AppConstants.DEFAULT_PRODUCT_IMAGE}
        title={title}
      />
      <CardContent>
        <Box sx={{ mb: 2 }}>
          <Typography gutterBottom variant="h6" component="div">
            {title}
          </Typography>
          <Typography variant="h6" sx={{ color: "text.secondary" }}>
            {originalPrice && (
              <span>
                <del>${originalPrice.toFixed(2)}</del>{" "}
              </span>
            )}
            <strong style={{ color: "red", marginRight: "10px" }}>
              ${promotionalPrice.toFixed(2)}
            </strong>
            {discountPercentage && (
              <Chip
                size="small"
                label={`${discountPercentage}% off`}
                color="error"
              />
            )}
          </Typography>
        </Box>
        {/* <Typography variant="body2" sx={{ color: "text.secondary" }}>
          {description}
        </Typography> */}
      </CardContent>
      <CardActions sx={{ mb: 1, mx: 1, justifyContent: "space-between" }}>
        <Button size="small" variant="outlined" onClick={onAddToCart}>
          Add to cart
        </Button>
        <Button size="small" variant="contained" onClick={onBuyNow}>
          Buy now
        </Button>
      </CardActions>
    </Card>
  );
};

export default ProductListItem;
