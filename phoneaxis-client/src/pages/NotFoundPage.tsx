import { Box, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import ErrorOutlineIcon from "@mui/icons-material/ErrorOutline";

const NotFoundPage = () => {
  const navigate = useNavigate();

  return (
    <Box
      display="flex"
      flexDirection="column"
      alignItems="center"
      justifyContent="center"
      mt={10}
    >
      <ErrorOutlineIcon sx={{ fontSize: 100, color: "primary.main", mb: 2 }} />

      <Typography variant="h2" fontWeight="bold" gutterBottom>
        404
      </Typography>

      <Typography variant="h5" color="text.secondary" gutterBottom>
        Oops! The page you're looking for doesn't exist.
      </Typography>

      <Typography variant="body1" mb={3}>
        It might have been moved or deleted.
      </Typography>

      <Button
        variant="contained"
        color="primary"
        size="large"
        onClick={() => navigate("/")}
      >
        Back to Home
      </Button>
    </Box>
  );
};

export default NotFoundPage;
