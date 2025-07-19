import { ArrowForward } from "@mui/icons-material";
import {
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";

const Banner = ({
  image,
  text,
  title,
  bgColor,
}: {
  image: string;
  text: string;
  title: string;
  bgColor: string;
}) => {
  return (
    <Card
      sx={{
        display: "flex",
        justifyContent: "space-between",
        backgroundColor: `${bgColor}`,
        height: "200px",
      }}
    >
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardContent sx={{ flex: "1 0 auto" }}>
          <Typography component="div" variant="subtitle1">
            {title}
          </Typography>
          <Typography
            variant="body2"
            component="div"
            sx={{ color: "text.secondary" }}
          >
            {text}
          </Typography>
        </CardContent>
        <Box sx={{ display: "flex", alignItems: "center", pl: 1, pb: 1 }}>
          <Button sx={{ textAlign: "center" }}>
            <Typography variant="subtitle2">Shop now</Typography>
            <ArrowForward sx={{ ml: 1 }}></ArrowForward>
          </Button>
        </Box>
      </Box>
      <CardMedia
        component="img"
        sx={{
          height: "auto",
          width: "auto",
          py: 2,
          px: 4,
        }}
        src={`${image}`}
        alt="Live from space album cover"
      />
    </Card>
  );
};

export default Banner;
