import { Box } from "@mui/material";
import Content from "./Content";
import Footer from "./Footer";
import Header from "./Header";

function MainLayout() {
  return (
    <Box
      sx={{
        display: "flex",
        flexDirection: "column",
        minHeight: "100vh",
      }}
    >
      <Header></Header>

      <Box sx={{ flex: 1 }}>
        <Content></Content>
      </Box>

      <Footer></Footer>
    </Box>
  );
}

export default MainLayout;
