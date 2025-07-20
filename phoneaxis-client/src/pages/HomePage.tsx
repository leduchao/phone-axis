import { ArrowForward } from "@mui/icons-material";
import {
  Avatar,
  AvatarGroup,
  Box,
  Button,
  Grid,
  Typography,
} from "@mui/material";
import { ROUTES } from "../routes";
import Banner from "../components/Banner";
import ProductList from "../components/ProductList";
import {
  avatars,
  banners,
  itemData,
  latestProducts,
  products,
  productTypes,
} from "../constants/fake-data";

function HomePage() {
  return (
    <Box component={"div"}>
      <Grid container spacing={3} columns={{ xs: 1, md: 16 }} pt={10} mb={15}>
        <Grid size={{ xs: 1, md: 6 }} display="flex" flexDirection="column">
          <Box>
            <Typography variant="h3" fontWeight={"bold"} gutterBottom>
              Find Your
              <br></br>
              Perfect Tech
              <br></br>
              Companion Here
            </Typography>
          </Box>
          <Typography variant="body2" mt={2} mb={5}>
            Founded with a vision to redefine the way you shop for electronics,
            HiTech is your one-stop destination for all things tech
          </Typography>

          <Box sx={{ width: "fit-content" }}>
            <Button variant="contained" href={`${ROUTES.Shop}`} sx={{ mb: 3 }}>
              Shop now <ArrowForward sx={{ ml: 1 }}></ArrowForward>{" "}
            </Button>
          </Box>

          <Box display="flex" alignItems="center" gap={2} mt={"auto"}>
            <AvatarGroup
              renderSurplus={(surplus) => (
                <span>+{surplus.toString()[0]}k</span>
              )}
              total={3521}
            >
              {avatars.map((item) => (
                <Avatar alt={`${item.alt}`} src={`${item.src}`} />
              ))}
            </AvatarGroup>
            <Box>
              <Typography variant="body2">
                Proven Excellence <strong>4.5</strong>-Star Rating
              </Typography>
              <Typography variant="body2">
                Over <strong>3,500</strong> Customers
              </Typography>
            </Box>
          </Box>
        </Grid>
        <Grid size={{ xs: 1, md: 10 }} container columns={{ xs: 1, md: 16 }}>
          <Grid size={{ xs: 1, md: 6 }}>
            <Box
              position={"relative"}
              sx={{
                background:
                  "linear-gradient(180deg,rgba(255, 255, 255, 1) 0%, rgba(169, 219, 218, 1) 100%)",
              }}
              height={"350px"}
              display={{ xs: "none", md: "flex" }}
              justifyContent={"center"}
              alignItems={"center"}
              borderRadius={2}
            >
              <Box
                component={"img"}
                height={"85%"}
                src={`${itemData[0].img}`}
                alt={itemData[0].title}
                loading="lazy"
                style={{
                  position: "absolute",
                  bottom: 0,
                }}
              />
            </Box>
          </Grid>
          <Grid size={{ xs: 1, md: 10 }}>
            <Box
              sx={{
                background:
                  "linear-gradient(0deg,rgba(255, 255, 255, 1) 0%, rgba(230, 196, 163, 1) 100%)",
              }}
              height={"600px"}
              display={"flex"}
              justifyContent={"center"}
              alignItems={"center"}
              borderRadius={2}
            >
              <Box
                component={"img"}
                src={`${itemData[1].img}`}
                alt={itemData[1].title}
                loading="lazy"
                height={"85%"}
              />
            </Box>
          </Grid>
        </Grid>
      </Grid>

      <Box>
        <Box display={"flex"} justifyContent={"space-between"} mb={15}>
          {productTypes.map((item) => (
            <Box
              component={"a"}
              display={"flex"}
              justifyContent={"center"}
              alignItems={"center"}
              flexDirection={"column"}
              href={`${ROUTES.Categories}/${item.href}`}
              sx={{ textDecoration: "none" }}
            >
              <Box
                component={"img"}
                src={`${item.img}`}
                alt={item.title}
                loading="lazy"
                sx={{
                  width: 100,
                  height: 100,
                }}
              ></Box>
              <Typography
                variant="subtitle1"
                textAlign={"center"}
                color="black"
              >
                {item.title}
              </Typography>
            </Box>
          ))}
        </Box>

        <Box sx={{ backgroundColor: "" }}>
          <ProductList
            products={products}
            title="Best Selling Products"
            hasButton={true}
            buttonText="View all"
          ></ProductList>

          <Grid container columns={{ xs: 1, md: 3 }} spacing={3} my={15}>
            {banners.map((item) => (
              <Grid size={1}>
                <Banner
                  image={`${item.image}`}
                  text={`${item.text}`}
                  title={`${item.title}`}
                  bgColor={`${item.bgColor}`}
                ></Banner>
              </Grid>
            ))}
          </Grid>

          <ProductList
            products={latestProducts}
            title="Latest Products"
            hasButton={true}
            buttonText="View all"
          ></ProductList>
        </Box>
      </Box>
    </Box>
  );
}

export default HomePage;
