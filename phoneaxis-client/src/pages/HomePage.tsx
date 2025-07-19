import { ArrowForward } from "@mui/icons-material";
import {
  Avatar,
  AvatarGroup,
  Box,
  Button,
  Divider,
  Grid,
  Typography,
} from "@mui/material";
import { ROUTES } from "../routes";
import ProductListItem from "../components/ProductListItem";
import Banner from "../components/Banner";

const itemData = [
  {
    img: "../src/assets/660bb03841ea3221d9a0b61f_hero-01.png",
    title: "Bed",
  },
  {
    img: "../src/assets/660bb0383ebf70d6ce691819_hero-02.png",
    title: "Books",
  },
];

const productType = [
  {
    img: "../src/assets/smartphone.svg",
    title: "Smartphone",
    href: "smartphones",
  },
  {
    img: "../src/assets/smartwatch.svg",
    title: "Smartwatch",
    href: "smartwatch",
  },
  {
    img: "../src/assets/controller.svg",
    title: "Game & Video",
    href: "video-game",
  },
  {
    img: "../src/assets/automation.svg",
    title: "Home Automation",
    href: "home-automation",
  },
  {
    img: "../src/assets/headphone.svg",
    title: "Headphone",
    href: "headphones",
  },
  {
    img: "../src/assets/laptop.svg",
    title: "Laptop",
    href: "laptops",
  },
  {
    img: "../src/assets/tech-gadget.svg",
    title: "Tech Gadget",
    href: "tech-gadget",
  },
];

const products = [
  {
    image:
      "https://cdn.prod.website-files.com/66066cd26f345c1bf92964bb/660a78c4bec017e77389bc5c_product-thumb-09-p-500.jpg",
    name: "NexGen Galaxy X",
    price: 599.0,
  },
  {
    image:
      "https://cdn.prod.website-files.com/66066cd26f345c1bf92964bb/660a7ee7206686f4fca755d6_product-thumb-10.jpg",
    name: "VisionPro Compact Camera",
    price: 680.0,
  },
  {
    image:
      "https://cdn.prod.website-files.com/66066cd26f345c1bf92964bb/660bae43dac26f3ad29ff86f_product-thumb-11-p-500.jpg",
    name: "ZenithStream Ultrabook",
    price: 620.0,
  },
  {
    image:
      "https://cdn.prod.website-files.com/66066cd26f345c1bf92964bb/660bae336cc1437adb60d881_product-thumb-15.jpg",
    name: "SonicStream Mini Speaker",
    price: 160.0,
  },
];

const banners = [
  {
    image:
      "https://cdn.prod.website-files.com/65dc3354ff2046f1c1a5251f/660baaaba6bcbb564834130e_banner-02.png",
    text: "18% discount",
    title: "Smartphones & Accessories",
    bgColor: "#cce3e8",
  },
  {
    image:
      "https://cdn.prod.website-files.com/65dc3354ff2046f1c1a5251f/660baaac23087acbd4d23011_banner-01.png",
    text: "New arrival",
    title: "Portable Bluetooth Speaker",
    bgColor: "#edd5cb",
  },
  {
    image:
      "https://cdn.prod.website-files.com/65dc3354ff2046f1c1a5251f/660baaac7bfd787a4ce4a37e_banner-03.png",
    text: "12th generation",
    title: "StellarView Notebook",
    bgColor: "#cbeddb",
  },
];

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
              <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
              <Avatar alt="Travis Howard" src="/static/images/avatar/2.jpg" />
              <Avatar alt="Agnes Walker" src="/static/images/avatar/4.jpg" />
              <Avatar
                alt="Trevor Henderson"
                src="/static/images/avatar/5.jpg"
              />
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
              height={"300px"}
              display={{ xs: "none", md: "flex" }}
              justifyContent={"center"}
              alignItems={"center"}
              borderRadius={2}
            >
              <Box
                component={"img"}
                height={"90%"}
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
          {productType.map((item) => (
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
          <Box display={"flex"} justifyContent={"space-between"}>
            <Typography variant="h4">Best Selling Products</Typography>
            <Button href={`${ROUTES.Shop}`}>
              View All <ArrowForward sx={{ ml: 1 }}></ArrowForward>
            </Button>
          </Box>

          <Divider sx={{ my: 2 }}></Divider>

          <Grid container columns={{ xs: 2, md: 4 }} spacing={3}>
            {products.map((item) => (
              <Grid size={1}>
                <ProductListItem
                  image={`${item.image}`}
                  name={`${item.name}`}
                  originalPrice={item.price}
                ></ProductListItem>
              </Grid>
            ))}
          </Grid>

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
        </Box>
      </Box>
    </Box>
  );
}

export default HomePage;
