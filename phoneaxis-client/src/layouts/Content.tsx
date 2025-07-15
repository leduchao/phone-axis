import { Box, Container, useMediaQuery, useTheme } from "@mui/material";
import { Outlet } from "react-router";

function Content() {
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("sm"));
  const headerHeight = isMobile ? 56 : 64;

  return (
    <Box
      sx={{
        mt: `${headerHeight}px`,
      }}
    >
      <Container maxWidth="xl" sx={{ py: { xs: 2, sm: 3 } }}>
        <Outlet />
      </Container>
    </Box>
  );
}

export default Content;
