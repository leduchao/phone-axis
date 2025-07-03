import { Box } from "@mui/material";
import Typography from "@mui/material/Typography";

function Footer() {
  return (
    <Box
      sx={{
        backgroundColor: "gray",
        height: "68.5px",
        width: "100%",
        alignContent: "center",
        textAlign: "center",
      }}
    >
      <Typography variant="body1" component="div">
        Footer
      </Typography>
    </Box>
  );
}

export default Footer;
