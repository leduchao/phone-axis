import { Box, Container, useMediaQuery, useTheme } from "@mui/material";
import { Outlet } from "react-router";

function Content() {
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("sm"));
  const headerHeight = isMobile ? 56 : 68.5;

  return (
    <Box
      sx={{
        mt: `${headerHeight}px`,
        height: `calc(100vh - ${headerHeight * 2}px)`,
        maxHeight: `calc(100vh - ${headerHeight * 2}px)`,
        overflowY: "auto",
        // backgroundColor: "#EFF0E0",
      }}
    >
      <Container sx={{ py: { xs: 2, sm: 3 } }}>
        <Outlet />
      </Container>
    </Box>
  );
}

export default Content;
