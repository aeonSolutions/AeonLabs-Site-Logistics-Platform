<?php
/**
 * AesCipher
 *
 * Encode/Decode text by password using AES-128-CBC algorithm
 */
class AesCipher
{
    protected $CIPHER = 'AES-128-CBC';
    protected $INIT_VECTOR_LENGTH = 16;

    /**
     * Encoded/Decoded data
     *
     * @var null|string
     */
    protected $data;
    /**
     * Initialization vector value
     *
     * @var string
     */
    protected $initVector;
    /**
     * Error message if operation failed
     *
     * @var null|string
     */
    protected $errorMessage;
    /**
     * decoded / encoded data string
     *
     * @var null|string
     */	
	protected $resultData;

    /**
     * AesCipher constructor.
     *
     * @param string $initVector        Initialization vector value
     * @param string|null $data         Encoded/Decoded data
     * @param string|null $errorMessage Error message if operation failed
     */
    public function __construct($initVector="", $data = null, $errorMessage =null)
    {
        $this->initVector = $initVector;
        $this->data = $data;
        $this->errorMessage = $errorMessage;
    }

    /**
     * Encrypt input text by AES-128-CBC algorithm
     *
     * @param string $secretKey 16/24/32 -characters secret password
     * @param string $plainText Text for encryption
     *
     * @return self Self object instance with data or error message
     */
    public function encrypt($secretKey, $plainText, $useIV)
    {
        try {
            // Check secret length
            if (!$this->isKeyLengthValid($secretKey)):
				$this->errorMessage="Secret key's length must be 128, 192 or 256 bits (".strlen($secretKey).")";
				return false;
            endif;

            // Get random initialization vector
            if($useIV==""):
				$this->initVector = bin2hex(openssl_random_pseudo_bytes($this->INIT_VECTOR_LENGTH / 2));
			else:
				$this->initVector = $useIV;
			endif;
            // Encrypt input text
            $raw = openssl_encrypt(
                $plainText,
                $this->CIPHER,
                $secretKey,
                OPENSSL_RAW_DATA,
                $this->initVector
            );

            // Return base64-encoded string: initVector + encrypted result

			$result = base64_encode($this->initVector . $raw);

            if ($result === false) {
                // Operation failed

				$this->errorMessage=openssl_error_string();
                return new static($this->$initVector, null, openssl_error_string());
            }
			$this->resultData=$result;
            // Return successful encoded object
            return new static($this->initVector, $result);
        } catch (\Exception $e) {
            // Operation failed
			$this->errorMessage=$e->getMessage();
			return false;
        }
    }

    /**
     * Decrypt encoded text by AES-128-CBC algorithm
     *
     * @param string $secretKey  16/24/32 -characters secret password
     * @param string $cipherText Encrypted text
     *
     * @return self Self object instance with data or error message
     */
    public function decrypt($secretKey, $cipherText)
    {
        try {
            // Check secret length
            if (!$this->isKeyLengthValid($secretKey)) {
				$this->errorMessage="Secret key's length must be 128, 192 or 256 bits (".strlen($secretKey).")";
				return false;
            }

            // Get raw encoded data
            $encoded = base64_decode($cipherText);
            // Slice initialization vector
            $this->initVector = substr($encoded, 0, $this->INIT_VECTOR_LENGTH);		
			
            // Slice encoded data
            $data = substr($encoded, $this->INIT_VECTOR_LENGTH);
				
            // Trying to get decrypted text
            $decoded = openssl_decrypt(
                $data,
                $this->CIPHER,
                $secretKey,
                OPENSSL_RAW_DATA,
                $this->initVector
            );
		
            if ($decoded === false) {
				// Operation failed
				$this->errorMessage=openssl_error_string();		
                return new static(isset($this->$initVector), null, openssl_error_string());
            }
            // Return successful decoded object
			$this->resultData=$decoded;
            return new static($this->initVector, $decoded);
        } catch (\Exception $e) {
			// Operation failed
			$this->errorMessage=$e->getMessage();
            return new static(isset($this->initVector), null, $e->getMessage());
        }
    }

    /**
     * Check that secret password length is valid
     *
     * @param string $secretKey 16/24/32 -characters secret password
     *
     * @return bool
     */
    public  function isKeyLengthValid($secretKey)
    {
        $length = strlen($secretKey);

        return $length == 16 || $length == 24 || $length == 32;
    }

    /**
     * Get encoded/decoded data
     *
     * @return string|null
     */
    public function getData()
    {
        return $this->data;
    }

    /**
     * Get initialization vector value
     *
     * @return string|null
     */
    public function getInitVector()
    {
        return $this->initVector!==null ? $this->initVector : "";
    }

    /**
     * Get error message
     *
     * @return string|null
     */
    public function getResult()
    {
        return $this->resultData;
    }
	
	/**
     * Get error message
     *
     * @return string|null
     */
    public function getErrorMessage()
    {
        return $this->errorMessage;
    }

    /**
     * Check that operation failed
     *
     * @return bool
     */
    public function hasError()
    {
        return $this->errorMessage !== null;
    }


}

?>